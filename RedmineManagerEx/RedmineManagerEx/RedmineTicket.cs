// <copyright file="IssueEx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Redmine.Net.Api.Types;
using System;
using System.Data;

namespace RedmineManagerEx
{
    public class RedmineTicket : BaseIssueEx
    {
        private Issue redmineIssue = new Issue();

        /// <summary>
        /// Initializes a new instance of the <see cref="RedmineTicket"/> class.
        /// </summary>
        /// <param name="source"></param>
        public RedmineTicket(DataRow source)
        {
            this.ConvertToIssue(source);
        }

        private void ConvertToIssue(DataRow source)
        {
            this.redmineIssue.Subject = source.Field<string>(TitleStr);
            this.redmineIssue.Id = source.Field<int>(IssueIDStr);
        }

        /// <inheritdoc/>
        public override string Title { get => this.redmineIssue.Subject; }

        /// <inheritdoc/>
        public override int IssueID { get => this.redmineIssue.Id; }
    }
}