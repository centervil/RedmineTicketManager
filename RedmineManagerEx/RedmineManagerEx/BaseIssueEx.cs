// <copyright file="IIssueEx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RedmineManagerEx
{
    public abstract class BaseIssueEx
    {
        /// <summary>
        /// Gets titleの項目名
        /// </summary>
        public static string TitleStr { get => "タイトル"; }

        /// <summary>
        /// Gets projectIDの項目名
        /// </summary>
        public static string IssueIDStr { get => "チケットID"; }

        /// <summary>
        /// Gets title
        /// </summary>
        public virtual string Title { get; }

        /// <summary>
        /// Gets projectID
        /// </summary>
        public virtual int IssueID { get; }
    }
}