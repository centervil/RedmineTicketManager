// <copyright file="IssueEx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Redmine.Net.Api.Types;
using System;
using System.Data;

namespace RedmineManagerEx
{
    public class RedmineTicket : IIssueEx
    {
        private Issue redmineIssue = new Issue();

        public RedmineTicket(DataRow source)
        {
            this.ConvertToIssue(source);
        }

        private void ConvertToIssue(DataRow source)
        {
            this.redmineIssue.Subject = source.Field<string>(this.TitleStr);
            this.redmineIssue.Id = source.Field<int>(this.IssueIDStr);
        }

        /// <inheritdoc/>
        public string TitleStr => "タイトル";

        /// <inheritdoc/>
        public string IssueIDStr => "チケットID";

        /// <inheritdoc/>
        public string Title { get => this.redmineIssue.Subject; }

        /// <inheritdoc/>
        public int IssueID { get => this.redmineIssue.Id; }
    }
}