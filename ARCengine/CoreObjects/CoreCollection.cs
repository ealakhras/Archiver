using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCengine.CoreObjects
{
    public class CoreCollection : CollectionBase
    {
        #region constructors
        public CoreCollection(Type t) : base()
        {
            mType = t;
            mRefreshState = RefreshStateEnum.NeedsRefreshing;
        }
        #endregion

        #region members
        private Type mType;
        protected RefreshStateEnum mRefreshState;
        #endregion

        #region properties
        public RefreshStateEnum RefreshState
        {
            get
            {
                return mRefreshState;
            }
        }
        #endregion

        #region methods
        protected override void OnClear()
        {
            base.OnClear();
            //mRefreshState = RefreshStateEnum.NeedsRefreshing;
        }

        protected virtual void Read()
        {
            // i do nothing.
        }

        /// <summary>
        /// refreshes the collection by executing Read()
        /// </summary>
        /// <param name="onlyIfNeeded">only do refresh if RefreshState says NeedsRefreshing</param>
        public void Refresh(bool onlyIfNeeded = false)
        {
            if (onlyIfNeeded && mRefreshState != RefreshStateEnum.NeedsRefreshing)
            {
                return;
            }
            mRefreshState = RefreshStateEnum.CurrentlyRefreshing;
            Read();
            mRefreshState = RefreshStateEnum.HasBeenRefreshed;
        }
        #endregion
    }
}