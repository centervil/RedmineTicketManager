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
            dataSource.Columns.Add(BaseIssueEx.TitleStr);
            dataSource.Columns.Add(BaseIssueEx.IssueIDStr, Type.GetType("System.Int32"));
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
            #region Mockの設定
            var mockIssue = new Mock<BaseIssueEx>();
            mockIssue.SetupGet(x => x.Title).Returns(TEST_TITLE);
            mockIssue.SetupGet(x => x.IssueID).Returns(TEST_NO);
            #endregion

            #region issueListの設定
            var issueList = new List<BaseIssueEx>();
            issueList.Add(mockIssue.Object);
            #endregion

            var RedmineTicketFormatter = new IssuesFormatter(new RedmineTicketFactory());
            var dataSource = RedmineTicketFormatter.ConvertToDataTable(ref issueList);
            var sourcelist = dataSource.AsEnumerable().ToList<DataRow>();

            Assert.AreEqual(sourcelist[0].Field<string>(BaseIssueEx.TitleStr), TEST_TITLE);
            Assert.AreEqual(sourcelist[0].Field<int>(BaseIssueEx.IssueIDStr), TEST_NO);
        }
    }
}
