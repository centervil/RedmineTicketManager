using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine.Net.Api.Types;

namespace RedmineManagerEx
{
    /// <summary>
    /// IssueのListとDataTable形式のデータセットとの相互変換クラス
    /// </summary>
    public class IssuesFormatter
    {
        private IIssueFactory issueFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssuesFormatter"/> class.
        /// </summary>
        /// <param name="issueFactory"></param>
        public IssuesFormatter(IIssueFactory issueFactory)
        {
            this.issueFactory = issueFactory;
        }

        /// <summary>
        /// DataSource ⇒ issueList変換
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns>List of IIssueEx</returns>
        public List<IIssueEx> ConvertToIssues(ref DataTable dataSource)
        {
            var issueList = new List<IIssueEx>();
            var sourcelist = dataSource.AsEnumerable().ToList<DataRow>();
            foreach (var source in sourcelist)
            {
                IIssueEx issue = this.issueFactory.Create(source);
                issueList.Add(issue);
            }

            return issueList;

            //issueList[0].Title = list[0].Field<string>("タイトル");
            //issueList[0].IssueID = list[0].Field<int>("チケットID");
        }
    }
}
