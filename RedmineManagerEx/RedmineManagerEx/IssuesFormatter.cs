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
        public List<BaseIssueEx> ConvertToIssues(ref DataTable dataSource)
        {
            var issueList = new List<BaseIssueEx>();
            var sourcelist = dataSource.AsEnumerable().ToList<DataRow>();
            foreach (var source in sourcelist)
            {
                BaseIssueEx issue = this.issueFactory.Create(source);
                issueList.Add(issue);
            }

            return issueList;
        }

        /// <summary>
        /// IssueList ⇒ DataSource変換
        /// </summary>
        /// <param name="issueList"></param>
        /// <returns></returns>
        public DataTable ConvertToDataTable(ref List<BaseIssueEx> issueList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(BaseIssueEx.TitleStr);
            dataTable.Columns.Add(BaseIssueEx.IssueIDStr, Type.GetType("System.Int32"));

            foreach (var issue in issueList)
            {
                dataTable.Rows.Add(issue.Title, issue.IssueID);
            }

            return dataTable;
        }
    }
}
