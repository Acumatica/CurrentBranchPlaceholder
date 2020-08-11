using PX.Data;
using PX.Data.SQLTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.Common
{
  [PXCacheName("Current Branch Placeholder")]
  public class CurrentBranchPlaceholder : IBqlTable
  {
    #region CurrentBranch
    public abstract class currentBranch : IBqlField { }

    [PXDBCalced(typeof(CurrentBranchOp), typeof(int?))]
    [PXInt]
    [PXUIField(DisplayName = "Current Branch")]
    public virtual int? CurrentBranch
    {
      get;
      set;
    }
    #endregion
  }
}