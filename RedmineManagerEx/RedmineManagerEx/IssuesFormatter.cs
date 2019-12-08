using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine.Net.Api.Types;

namespace RedmineManagerEx
{
    public class IssuesFormatter
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IssuesFormatter"/> class.
        /// </summary>
        /// <param name="dataSource">IssueListに変換する表形式データ</param>
        public IssuesFormatter(DataTable dataSource)
        {
            this.DataSource = dataSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IssuesFormatter"/> class.
        /// </summary>
        /// <param name="issues">表形式データに変換するIssueList</param>
        public IssuesFormatter(List<ICloneable> issues)
        {
            this.IssueList = issues;
        }

        public DataTable DataSource { get; private set; }

        public List<ICloneable> IssueList { get; private set; }
    }
}
