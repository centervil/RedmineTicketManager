using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedmineManagerEx.Test
{
    [TestClass]
    public class TestForIssuesFormatter
    {
        [TestMethod]
        public void DataSourceToIssues()
        {
            var dataSource = new DataTable();
            var formatter = new IssuesFormatter(dataSource);
            var IssueList = formatter.IssueList;
        }
    }
}
