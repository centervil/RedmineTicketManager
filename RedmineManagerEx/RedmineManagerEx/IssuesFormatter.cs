// <copyright file="IssuesFormatter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace RedmineManagerEx
{
    /// <summary>
    /// IssueのListとDataTable形式のデータセットとの相互変換クラス
    /// </summary>
    public class IssuesFormatter
    {
        private readonly IIssueFactory issueFactory;

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
        /// <returns>List of BaseIssueEx</returns>
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
        /// <returns>DataTable</returns>
        public DataTable ConvertToDataTable(ref List<BaseIssueEx> issueList)
        {
            var dataTable = new DataTable();
            var infoArray = issueList[0].GetType().GetProperties();

            foreach (var property in issueList[0].GetType().GetProperties())
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (var issue in issueList)
            {
                dataTable.Rows.Add(issue.Title, issue.IssueID);
            }

            return dataTable;
        }
    }
}
