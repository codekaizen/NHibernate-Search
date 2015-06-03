using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using NHibernate.Criterion;

namespace NHibernate.Search
{
    using System;

    [Obsolete("Use SetCriteriaQuery against IFullTextSession")]
    public static class SearchRestrictions
    {
        private static Lucene.Net.Util.Version _matchVersion = Lucene.Net.Util.Version.LUCENE_30;
        public static ICriterion Query(Lucene.Net.Search.Query luceneQuery)
        {
            return new LuceneQueryExpression(luceneQuery);
        }

        public static ICriterion Query(string luceneQuery)
        {
            QueryParser parser = new QueryParser(_matchVersion, string.Empty, new StandardAnalyzer(_matchVersion));
            return Query(parser.Parse(luceneQuery));
        }

        public static ICriterion Query(string defaultField, string luceneQuery)
        {
            QueryParser parser = new QueryParser(_matchVersion, defaultField, new StandardAnalyzer(_matchVersion));
            return Query(parser.Parse(luceneQuery));
        }
    }
}