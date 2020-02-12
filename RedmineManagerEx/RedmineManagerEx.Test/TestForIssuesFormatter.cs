using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RedmineManagerEx.Test
{
    [TestClass]
    public class TestForIssuesFormatter
    {
        #region define
        const string TEST_TITLE = "Test";
        const int TEST_NO = 1;
        #endregion

        [TestMethod]
        public void DataSourceToIssues()
        {
            #region DataTableの設定
            var dataSource = new DataTable();
            dataSource.Columns.Add(nameof(BaseIssueEx.Title));
            dataSource.Columns.Add(nameof(BaseIssueEx.IssueID), Type.GetType("System.Int32"));
            dataSource.Rows.Add(TEST_TITLE, TEST_NO);
            #endregion

            var RedmineTicketFormatter = new IssuesFormatter(new RedmineTicketFactory());
            var issueList = RedmineTicketFormatter.ConvertToIssues(ref dataSource);

            Assert.AreEqual(issueList[0].Title, TEST_TITLE);
            Assert.AreEqual(issueList[0].IssueID, TEST_NO);

        }

        [TestMethod]
        public void IssuesToDataSource()
        {
            #region redmineTicketの設定
            var dataSource = new DataTable();
            dataSource.Columns.Add(nameof(BaseIssueEx.Title));
            dataSource.Columns.Add(nameof(BaseIssueEx.IssueID), Type.GetType("System.Int32"));
            dataSource.Rows.Add(TEST_TITLE, TEST_NO);

            var redmineTicket = new RedmineTicket(dataSource.AsEnumerable().ToList<DataRow>()[0]);
            #endregion

            #region issueListの設定
            var issueList = new List<BaseIssueEx>();
            issueList.Add(redmineTicket);
            #endregion

            var RedmineTicketFormatter = new IssuesFormatter(new RedmineTicketFactory());
            var source = RedmineTicketFormatter.ConvertToDataTable(ref issueList);
            var sourcelist = source.AsEnumerable().ToList<DataRow>();

            Assert.AreEqual(sourcelist[0].Field<string>(nameof(redmineTicket.Title)), TEST_TITLE);
            Assert.AreEqual(sourcelist[0].Field<int>(nameof(redmineTicket.IssueID)), TEST_NO);
        }
    }
}
