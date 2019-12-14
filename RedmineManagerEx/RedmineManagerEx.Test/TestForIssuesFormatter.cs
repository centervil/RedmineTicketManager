using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RedmineManagerEx.Test
{
    [TestClass]
    public class TestForIssuesFormatter
    {
        [TestMethod]
        public void DataSourceToIssues()
        {
            #region define
            const string TEST_TITLE = "Test";
            #endregion

            #region Mockの設定
            var mockIssue = new Mock<IIssueEx>();
            mockIssue.SetupGet(x => x.TitleStr).Returns("タイトル");
            mockIssue.SetupGet(x => x.IssueIDStr).Returns("チケットID");
            #endregion

            #region DataTableの設定
            var dataSource = new DataTable();
            dataSource.Columns.Add(mockIssue.Object.TitleStr);
            dataSource.Columns.Add(mockIssue.Object.IssueIDStr, Type.GetType("System.Int32"));
            dataSource.Rows.Add(TEST_TITLE, 1);
            #endregion

            var RedmineTicketFormatter = new IssuesFormatter(new RedmineTicketFactory());
            var issueList = RedmineTicketFormatter.ConvertToIssues(ref dataSource);

            Assert.AreEqual(issueList[0].Title, TEST_TITLE);

        }
    }
}
