using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Utilities
{

    public static class Manager
    {
        public static List<SPData> GetListData()
        {
            const string DataColumn = "ID,Title";
            const string DataAPIAllData = "{0}/_api/lists/getbytitle('{1}')/items?$top=10&$select=" + DataColumn + "&$orderby=Modified desc";

            try
            {
                var results = new List<SPData>();

                //TODO: Enter your SharePoint site URL
                string sharepointSiteUrl = Convert.ToString("Enter the SharePoint Site URL");
                if (!string.IsNullOrEmpty(sharepointSiteUrl))
                {

                    //TODO: Enter List name  
                    string listname = "Enter List name";
                    string api = string.Format(DataAPIAllData, sharepointSiteUrl, listname);
                    if (!string.IsNullOrEmpty(listname))
                    {
                        //Invoke REST Call  
                        string response = TokenHelper.GetAPIResponse(api);
                        if (!String.IsNullOrEmpty(response))
                        {
                            JObject jobj = JObject.Parse(response);
                            JArray jarr = (JArray)jobj["d"]["results"];

                            //Write Response to Output  
                            foreach (JObject j in jarr)
                            {
                                SPData data = new SPData();
                                data.Title = Convert.ToString(j["Title"]);

                                results.Add(data);
                            }
                        }
                        return results;
                    }
                    else
                    {
                        throw new Exception("Custom Message");
                    }
                }
                else
                {
                    throw new Exception("Custom Message");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Custom Message");
            }
        }
    }
}
