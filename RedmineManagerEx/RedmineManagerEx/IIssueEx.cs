// <copyright file="IIssueEx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RedmineManagerEx
{
    public interface IIssueEx
    {
        /// <summary>
        /// Gets titleの項目名
        /// </summary>
        string TitleStr { get; }

        /// <summary>
        /// Gets projectIDの項目名
        /// </summary>
        string IssueIDStr { get; }

        /// <summary>
        /// Gets title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets projectID
        /// </summary>
        int IssueID { get; }
    }
}