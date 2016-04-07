using System;
using System.Collections.Generic;
using System.Web;
using System.Windows.Forms;
using Tao.LAS.Properties;

namespace Tao.LAS.Utils
{
    public enum UserAction { AddedComment, VotedUp, VotedDown, VotedOnItem, Subscribed, Uploaded, Registered, Favoured, Unsubscribed, Blogged, Unknown }

    public class PageParser
    {
        public static List<DataLine> ParsePage(PageData pageData)
        {
            var lineData = new List<DataLine>();
            var results = pageData.Data();
            
            // Parse DataLine objects from each line.
            foreach (var htmlResult in results)
            {
                // Identify the Action type, and parse based on that type
                var dl = ParseDataLine(ParseActionType(htmlResult),htmlResult);

                //If the dataline obj is null, it was alread logged, skip
                if (dl == null)
                    continue;

                // Add DataLine to our list if valid Otherwise Log error.
                if (ValidateDataLineObject(dl))
                    lineData.Add(dl);
                else
                {
                    var s = "DataLine object failed validation: " +
                            string.Format(
                                "Page id '{0}', user '{1}', action '{2}', target '{3}', targetLink '{4}', rawData '{5}'",
                                dl.PageID, dl.UserName, dl.Action, dl.Target, dl.TargetLink, dl.ContentRaw);
                    Logger.LogError(s);
                }
                Application.DoEvents();
            }
        
            return lineData;
        }

        private static bool ValidateDataLineObject(DataLine dlObj)
        {
            if (dlObj == null)
                return false;
            
            var retVal = true;
            
            // Validate Action field
            if (string.IsNullOrEmpty(dlObj.Action))
                retVal =  false;
            else
            {
                if (dlObj.Action.ToUpper().CompareTo("UNKNOWN ACTION") == 0)
                    retVal = false;   
            }

            // Validate Username field
            if (string.IsNullOrEmpty(dlObj.UserName))
                retVal = false;
            
            return retVal;
        }

        public static string GetActionText( UserAction action )
        {
            var retVal = string.Empty;
            switch (action)
            {
                case UserAction.AddedComment: retVal = "Added comment"; 
                    break;
                case UserAction.Favoured: retVal = "Added to favourites";
                    break;
                case UserAction.Registered: retVal = "Registered";
                    break;
                case UserAction.Subscribed: retVal = "Subscribed to channel";
                    break;
                case UserAction.Uploaded: retVal = "Uploaded content";
                    break;
                case UserAction.VotedOnItem: retVal = "Voted on item";
                    break;
                case UserAction.VotedDown: retVal = "Voted down";
                    break;
                case UserAction.VotedUp: retVal = "Voted up";
                    break;
                case UserAction.Unsubscribed: retVal = "Unsubscribed";
                    break;
                case UserAction.Blogged: retVal = "Blogged";
                    break;
            }
            return retVal;
        }

        private static UserAction ParseActionType(string rawData)
        {
            if (rawData.Contains(Resources.PageParser_Const_Comment))
                return UserAction.AddedComment;

            if (rawData.Contains(Resources.PageParser_Const_CommentVote)
                & rawData.Contains(Resources.PageParser_Const_Up))
                return UserAction.VotedUp;

            if (rawData.Contains(Resources.PageParser_Const_CommentVote)
                & rawData.Contains(Resources.PageParser_Const_Down))
                return UserAction.VotedDown;

            if (rawData.Contains(Resources.PageParser_Const_ItemVote))
                return UserAction.VotedOnItem;

            if (rawData.Contains(Resources.PageParser_Const_Subscribed))
                return UserAction.Subscribed;

            if (rawData.Contains(Resources.PageParser_Const_Uploaded))
                return UserAction.Uploaded;

            if (rawData.Contains(Resources.PageParser_Const_Registered))
                return UserAction.Registered;

            if (rawData.Contains(Resources.PageParser_Const_Favourited))
                return UserAction.Favoured;

            if (rawData.Contains(Resources.PageParser_Const_Unsubscribed))
                return UserAction.Unsubscribed;

            if (rawData.Contains(Resources.PageParser_Const_Blogged))
                return UserAction.Blogged;

            return UserAction.Unknown;
        }

        private static DataLine ParseDataLine(UserAction actionType, string strRawData)
        {
            switch (actionType)
            {
                case UserAction.AddedComment: return ParseAddedComment(strRawData); 
                case UserAction.Favoured:     return ParseFavourited(strRawData); 
                case UserAction.Registered:   return ParseRegistered(strRawData); 
                case UserAction.Subscribed:   return ParseSubscribed(strRawData); 
                case UserAction.Uploaded:     return ParseUploaded(strRawData); 
                case UserAction.VotedDown:    return ParseVotedDown(strRawData); 
                case UserAction.VotedOnItem:  return ParseVotedOnItem(strRawData); 
                case UserAction.VotedUp:      return ParseVotedUp(strRawData); 
                case UserAction.Unsubscribed: return ParseUnsubscribed(strRawData); 
                case UserAction.Blogged:      return ParseBlogged(strRawData); 
                default:  // Unhandled usertype
                    Logger.LogError("Unhandled UserAction Type:" + strRawData);
                    return null;
            }
        }
        
        private static string ParseUserName(string rawData)
        {
            const string strStart = "\">";
            const string strEnd = "</a>";
            var start = rawData.IndexOf(strStart, StringComparison.OrdinalIgnoreCase) + 2;
            var end = rawData.IndexOf(strEnd, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0) return null;
            return rawData.Substring(start, end - start);
        }

        private static string ParseTargetText(string rawData)
        {
            const string strStart = "\">";
            const string strEnd = "</a>";
            var start = rawData.LastIndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var end = rawData.LastIndexOf(strEnd, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0) return null;
            return rawData.Substring(start, end - start);
        }

        private static string ParseTargetLink(string rawData)
        {
            const string strStart = "<a href=\"";
            const string strEnd = "\">";
            var start = rawData.LastIndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var end = rawData.IndexOf(strEnd,start, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0) return null; 
            return HttpUtility.HtmlDecode(rawData.Substring(start, end - start));
        }
        
        private static DataLine ParseFavourited(string strRawData)
        {
            var dataLine = new DataLine
                               {
                                   ContentRaw   = strRawData,
                                   Action       = GetActionText(UserAction.Favoured),
                                   UserName     = ParseUserName(strRawData),
                                   Target       = ParseTargetText(strRawData),
                                   TargetLink   = ParseTargetLink(strRawData)
                               };
            return dataLine;
        }

        private static DataLine ParseAddedComment(string strRawData)
        {
            var dataLine = new DataLine
                               {
                                   ContentRaw   = strRawData,
                                   Action       = GetActionText(UserAction.AddedComment),
                                   UserName     = ParseUserName(strRawData),
                                   Target       = ParseTargetText(strRawData),
                                   TargetLink   = ParseTargetLink(strRawData)
                               };
            return dataLine;
        }

        private static DataLine ParseRegistered(string strRawData)
        {
            var dataLine = new DataLine
                               {
                                   ContentRaw   = strRawData,
                                   Action       = GetActionText(UserAction.Registered),
                                   UserName     = ParseUserName(strRawData),
                                   Target       = string.Empty,
                                   TargetLink   = string.Empty
                               };
            return dataLine;
        }

        private static DataLine ParseSubscribed(string strRawData)
        {
            var dataLine = new DataLine
                                {
                                    ContentRaw  = strRawData,
                                    Action      = GetActionText(UserAction.Subscribed),
                                    UserName    = ParseUserName(strRawData),
                                    Target      = ParseTargetText(strRawData),
                                    TargetLink  = ParseTargetLink(strRawData)
                                };
            return dataLine;
        }

        private static DataLine ParseUploaded(string strRawData)
        {
            string strTarget;
            string strTargetLink;

            // Parse the Target text
            var strStart = "\">";
            var strEnd = "</a>' in channel";
            var userStart = strRawData.IndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var start = strRawData.IndexOf(strStart, userStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var end = strRawData.IndexOf(strEnd, start,StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0)
                strTarget = null;
            else
                strTarget = strRawData.Substring(start, end - start);

            // Parse the Target Link
            strStart = "<a href=\"";
            strEnd = "\">";
            userStart = strRawData.IndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            start = strRawData.IndexOf(strStart, userStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            end = strRawData.IndexOf(strEnd,start, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0)
                strTargetLink = null;
            else
                strTargetLink = strRawData.Substring(start, end - start);


            var dataLine = new DataLine
                                {
                                    ContentRaw  = strRawData,
                                    Action      = GetActionText(UserAction.Uploaded),
                                    UserName    = ParseUserName(strRawData),
                                    Target      = strTarget,
                                    TargetLink  = strTargetLink
                                };
            return dataLine;
        }

        private static DataLine ParseVotedDown(string strRawData)
        {
            var strTarget = ParseTargetText(strRawData);
            string strTargetText;
            const string strStart = "comment by user '";
            const string strEnd = "'";
            var start = strTarget.IndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var end = strTarget.LastIndexOf(strEnd, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0)
                strTargetText = null;
            else
                strTargetText = strTarget.Substring(start, end - start);

            var dataLine = new DataLine
                                {
                                    ContentRaw  = strRawData,
                                    Action      = GetActionText(UserAction.VotedDown),
                                    UserName    = ParseUserName(strRawData),
                                    Target      = strTargetText,
                                    TargetLink  = ParseTargetLink(strRawData)
                                };
            return dataLine;
        }

        private static DataLine ParseVotedUp(string strRawData)
        {
            var strTarget = ParseTargetText(strRawData);
            string strTargetText;
            const string strStart = "comment by user '";
            const string strEnd = "'";
            var start = strTarget.IndexOf(strStart, StringComparison.OrdinalIgnoreCase) + strStart.Length;
            var end = strTarget.LastIndexOf(strEnd, StringComparison.OrdinalIgnoreCase);
            if (start < 0 || end < 0)
                strTargetText = null;
            else
                strTargetText = strTarget.Substring(start, end - start);
            
            var dataLine = new DataLine
                                {
                                    ContentRaw  = strRawData,
                                    Action      = GetActionText(UserAction.VotedUp),
                                    UserName    = ParseUserName(strRawData),
                                    Target      = strTargetText,
                                    TargetLink  = ParseTargetLink(strRawData)
                                };
            return dataLine;
        }

        private static DataLine ParseVotedOnItem(string strRawData)
        {
            var dataLine = new DataLine
                                {
                                    ContentRaw  = strRawData,
                                    Action      = GetActionText(UserAction.VotedOnItem),
                                    UserName    = ParseUserName(strRawData),
                                    Target      = ParseTargetText(strRawData),
                                    TargetLink  = ParseTargetLink(strRawData)
                                };
            return dataLine;
        }

        private static DataLine ParseUnsubscribed(string strRawData)
        {
            var dataLine = new DataLine
                                {
                                    ContentRaw = strRawData,
                                    Action = GetActionText(UserAction.Unsubscribed),
                                    UserName = ParseUserName(strRawData),
                                    Target = ParseTargetText(strRawData),
                                    TargetLink = ParseTargetLink(strRawData)
                                };
            return dataLine;
        }

        private static DataLine ParseBlogged(string strRawData)
        {
            var dataLine = new DataLine
                               {
                                   ContentRaw   = strRawData,
                                   Action       = GetActionText(UserAction.Blogged),
                                   UserName     = ParseUserName(strRawData),
                                   Target       = ParseTargetText(strRawData),
                                   TargetLink   = ParseTargetLink(strRawData)
                               };
            return dataLine;
        }

        public static string ParseDataAge(string rawData)
        {
            var retVal = "Unknown";
            if(rawData!=null)
            {
                var ss = HttpUtility.HtmlDecode(rawData);
                string[] splitStrings = {"* "};
                var a = ss.Split(splitStrings, StringSplitOptions.RemoveEmptyEntries);
                int end = a[0].IndexOf(" - <a ", 0, StringComparison.OrdinalIgnoreCase);
                retVal = a[0].Substring(0, end).Replace("less than a minute ago","<1 min ago");
            }
            return retVal;
        }
        
    }
}