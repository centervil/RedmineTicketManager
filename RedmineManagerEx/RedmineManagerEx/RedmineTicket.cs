// <copyright file="RedmineTicket.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Data;
using Redmine.Net.Api.Types;

namespace RedmineManagerEx
{
    /// <summary>
    /// RedmineIssueのラッパークラス
    /// </summary>
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

        /// <inheritdoc/>
        public override string Title { get => this.redmineIssue.Subject; }

        /// <inheritdoc/>
        public override int IssueID { get => this.redmineIssue.Id; }

        private void ConvertToIssue(DataRow source)
        {
            this.redmineIssue.Subject = source.Field<string>(nameof(this.Title));
            this.redmineIssue.Id = source.Field<int>(nameof(this.IssueID));
        }
    }
}