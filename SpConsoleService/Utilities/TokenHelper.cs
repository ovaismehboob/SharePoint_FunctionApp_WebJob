namespace Utilities
{
    public static class TokenHelper
    {
        public static string GetAPIResponse(string url)
        {
            string response = String.Empty;
            try
            {
                //Call to get AccessToken  
                string accessToken = GetSharePointAccessToken();
                //Call to get the REST API response from Sharepoint  
                System.Net.HttpWebRequest endpointRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                System.Net.WebResponse webResponse = endpointRequest.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static string GetSharePointAccessToken()
        {

            //TODO:Enter SharePoint Site URL
            Uri site = new Uri("Enter sharepoint site url");
            //TODO:Enter User email registered in AAD 
            string user = "";
            //TODO:Enter User password
            string pwd = "";
            
            string result;
            using (var authenticationManager = new AuthManager())
            {
                string accessTokenSP = authenticationManager.AcquireTokenAsync(site, user, pwd).Result;
                result = accessTokenSP;
            }
            return result;
        }

    }
}