using PX.Data;
using PX.Data.SQLTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.Common
{
    public sealed class CurrentBranchOp :
       IBqlCreator, IBqlOperand
    {
        public void Verify(PXCache cache, object item, List<object> pars, ref bool? result, ref object value)
        {
            value = cache.Graph.Accessinfo.BranchID;
        }
        // for 2018r1
        public void Parse(PXGraph graph, List<IBqlParameter> pars, List<Type> tables, List<Type> fields, List<IBqlSortColumn> sortColumns, StringBuilder text, BqlCommand.Selection selection)
        {
            if (graph != null && text != null)
            {
                PXMutableCollection.AddMutableItem(this);
                text.Append(' ');
                text.Append(graph.Accessinfo.BranchID);
                text.Append(' ');
            }
        }
        //for 2019r1
        //public bool AppendExpression(ref SQLExpression exp, PXGraph graph, BqlCommandInfo info, BqlCommand.Selection selection)
        //{
        //    if (graph == null || !info.BuildExpression) return true;
        //    PXMutableCollection.AddMutableItem(this);
        //    exp = new PX.Data.SQLTree.Constant(graph.Accessinfo.BranchID);
        //    return true;
        //}

        //for 2020r1
        public bool AppendExpression(ref SQLExpression exp, PXGraph graph, BqlCommandInfo info, BqlCommand.Selection selection)
        {
            if (graph == null || !info.BuildExpression) return true;
            PXMutableCollection.AddMutableItem(this);
            exp = new SQLConst(graph.Accessinfo.BranchID);
            return true;
        }
    }

}
