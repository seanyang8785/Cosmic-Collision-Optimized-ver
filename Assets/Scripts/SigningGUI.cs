using System.IO;
using UnityEngine;
using Unity.Services.Authentication;
using TMPro;
using Unity.Services.Core;
using Newtonsoft.Json;

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
                    StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
                    sw.WriteLine(JsonConvert.SerializeObject(Save.playerRecords));
                    sw.Close();
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
                        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
                        sw.WriteLine(JsonConvert.SerializeObject(Save.playerRecords));
                        sw.Close();
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
                    StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
                    sw.WriteLine(JsonConvert.SerializeObject(Save.playerRecords));
                    sw.Close();
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
                StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Players.json",append:false);
                sw.WriteLine(JsonConvert.SerializeObject(Save.playerRecords));
                sw.Close();
                anonymous = false;
            }
            AuthenticationService.Instance.SignOut();
            Debug.Log("Signed out.");
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
