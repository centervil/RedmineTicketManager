// <copyright file="RedmineTicketFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Data;

namespace RedmineManagerEx
{
    /// <summary>
    /// RedmineTicketのFactoryクラス
    /// </summary>
    public class RedmineTicketFactory : IIssueFactory
    {
        /// <inheritdoc/>
        public IIssueEx Create(DataRow source)
        {
            return new RedmineTicket(source);
        }
    }
}