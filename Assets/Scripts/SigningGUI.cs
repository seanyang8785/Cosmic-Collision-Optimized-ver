using System.IO;
using UnityEngine;
using Unity.Services.Authentication;
using TMPro;
using Unity.Services.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

public class SigningGUI : MonoBehaviour
{
    [SerializeField] GameObject anonymousNameInput;
    [SerializeField] GameObject usernameInput;
    [SerializeField] GameObject passwordInput;
    [SerializeField] Canvas SigningCanvas;
    [SerializeField] Canvas SignInCanvas;
    [SerializeField] TextMeshProUGUI signInInfo;

    public static string username;
    string password;
    public static bool anonymous = false;
    private void Start() {
        UnityServices.InitializeAsync();
        if(AuthenticationService.Instance.IsSignedIn){
            changeCanvas();
        }
        
    }
    async public void WithAnonymous(){
        username = anonymousNameInput.GetComponent<TMP_InputField>().text;
        if(username != ""){
            username += "-ano.";
            try{
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Logged in anonymously.");
                PlayerPrefs.DeleteKey("username");
                PlayerPrefs.SetString("username",username);
                if(!Save.playerRecords.ContainsKey(username)){
                    Save.playerRecords.Add(username,0);  
                    Save.updatePlayerRecordFile();
                }
                if(!Save.player_bought_goods_Records.ContainsKey(username)){
                    Save.player_bought_goods_Records.Add(username,new Save.player_bought_goods(new Dictionary<string,bool>()));  
                    Save.updateGoodsRecordFile();
                }
                else{
                    Dictionary<string,bool>.ValueCollection c = Save.player_bought_goods_Records[username].goods.Values;
                    int count = 0;
                    foreach(bool status in c){
                        GoodsManager.statuses[count] = status is true ? 1 : 0;
                        count++;
                    }
                    GoodsManager.statuses[0] ++;
                }
                if(!Save.coinsRecords.ContainsKey(username)){
                    Save.playerRecords.Add(username,300);  
                    Save.updatePlayerRecordFile();
                }
                changeCanvas();
                StartMemu.SigningInInit();
                anonymous = true;
            }
            catch(AuthenticationException ex){
                Debug.LogException(ex);
            }
            catch(RequestFailedException ex){
                Debug.LogException(ex);
            }
        }
    }

    async public void SignUp(){
        username = usernameInput.GetComponent<TMP_InputField>().text;
        password = passwordInput.GetComponent<TMP_InputField>().text;
        if(username != "HighestScore"){
            if(username != "" && password != ""){
                try{
                    await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
                    Debug.Log("Signed up with username and password.");
                    PlayerPrefs.DeleteKey("username");
                    PlayerPrefs.SetString("username",username);
                    if(!Save.playerRecords.ContainsKey(username)){
                        Save.playerRecords.Add(username,0);  
                        Save.updatePlayerRecordFile();
                    }
                    if(!Save.player_bought_goods_Records.ContainsKey(username)){
                        Save.player_bought_goods_Records.Add(username,new Save.player_bought_goods(new Dictionary<string,bool>()));  
                        Save.updateGoodsRecordFile();
                    }
                    if(!Save.coinsRecords.ContainsKey(username)){
                        Save.playerRecords.Add(username,300);  
                        Save.updatePlayerRecordFile();
                    }
                    changeCanvas();
                    StartMemu.SigningInInit();
                }
                catch(AuthenticationException ex){
                    Debug.LogException(ex);
                }
                catch(RequestFailedException ex){
                    Debug.LogException(ex);
                }
            }
        }
        else{
            Debug.Log("This name has been preserved for game recording.");
        }
    }

    async public void WithUsernamePassword(){
        username = usernameInput.GetComponent<TMP_InputField>().text;
        password = passwordInput.GetComponent<TMP_InputField>().text;  
        if(username != "" && password != ""){
            try{
                await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
                Debug.Log("Logged in with username and password.");
                PlayerPrefs.DeleteKey("username");
                PlayerPrefs.SetString("username",username);
                if(!Save.playerRecords.ContainsKey(username)){
                    Save.playerRecords.Add(username,0);  
                    Save.updatePlayerRecordFile();
                }
                if(!Save.player_bought_goods_Records.ContainsKey(username)){
                    Save.player_bought_goods_Records.Add(username,new Save.player_bought_goods(new Dictionary<string,bool>()));  
                    Save.updateGoodsRecordFile();
                }
                else{
                    Dictionary<string,bool>.ValueCollection c = Save.player_bought_goods_Records[username].goods.Values;
                    int count = 0;
                    foreach(bool status in c){
                        GoodsManager.statuses[count] = status is true ? 1 : 0;
                        count++;
                    }
                    GoodsManager.statuses[0] ++;
                }
                if(!Save.coinsRecords.ContainsKey(username)){
                    Save.playerRecords.Add(username,300);  
                    Save.updatePlayerRecordFile();
                }
                changeCanvas();
                StartMemu.SigningInInit();
            }
            catch(AuthenticationException ex){
                Debug.LogException(ex);
            }
            catch(RequestFailedException ex){
                Debug.LogException(ex);
            }
        }
    }

    public void signOut(){
        if(AuthenticationService.Instance.IsSignedIn){
            if(anonymous){
                Save.playerRecords.Remove(username);
                Save.updatePlayerRecordFile();
                anonymous = false;
            }
            AuthenticationService.Instance.SignOut();
            Debug.Log("Signed out.");
            GoodsManager.statuses = new List<int>(){2,0,0,0,0,0,0,0,0,0,0};
        }
        else{
            Debug.Log("You haven't signed in yet.");
        }
        SignInCanvas.enabled = false;
        usernameInput.GetComponent<TMP_InputField>().text = "";
        passwordInput.GetComponent<TMP_InputField>().text = "";
        anonymousNameInput.GetComponent<TMP_InputField>().text = "";
        SigningCanvas.enabled = true;
    }

    public void changeCanvas(){
        SigningCanvas.enabled = false;
        SignInCanvas.enabled = true;
        username = PlayerPrefs.GetString("username");
        if(username.Length > 8){
            signInInfo.text = username.Substring(0,8) + "...";
        }
        else{
            signInInfo.text = username;
        }
    }

    void OnApplicationQuit() {
        if(AuthenticationService.Instance.IsSignedIn){
            if(anonymous){
                Save.playerRecords.Remove(username);
                anonymous = false;
            }
            AuthenticationService.Instance.SignOut();
        }
    }
}
