using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace com.centralaz.RoomManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ReservationWorkflowTriggerService : Service<ReservationWorkflowTrigger>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationWorkflowTriggerService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReservationWorkflowTriggerService( RockContext context ) : base( context ) { }

        /// <summary>
        /// The cach e_ key
        /// </summary>
        private const string CACHE_KEY = "Rock:ReservationWorkflowTriggers";

        /// <summary>
        /// Gets the cached triggers.
        /// </summary>
        /// <returns></returns>
        public static List<ReservationWorkflowTrigger> GetCachedTriggers()
        {
            return GetOrAddExisting( () => LoadCache() );
        }

        /// <summary>
        /// Gets the or add existing.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <returns></returns>
        private static List<ReservationWorkflowTrigger> GetOrAddExisting( Func<List<ReservationWorkflowTrigger>> factory )
        {
            RockMemoryCache cache = RockMemoryCache.Default;

            var value = cache.Get( CACHE_KEY ) as List<ReservationWorkflowTrigger>;
            if ( value != null )
            {
                return value;
            }

            value = factory();
            if ( value != null )
            {
                cache.Set( CACHE_KEY, value, new CacheItemPolicy() );
            }
            return value;
        }

        /// <summary>
        /// Loads the cache.
        /// </summary>
        /// <returns></returns>
        private static List<ReservationWorkflowTrigger> LoadCache()
        {
            var triggers = new List<ReservationWorkflowTrigger>();

            using ( var rockContext = new RockContext() )
            {
                foreach ( var trigger in new ReservationWorkflowTriggerService( rockContext )
                    .Queryable().AsNoTracking() )
                {
                    triggers.Add( trigger.Clone( false ) );
                }
            }

            return triggers;
        }

        /// <summary>
        /// Flushes the cached triggers.
        /// </summary>
        public static void FlushCachedTriggers()
        {
            RockMemoryCache cache = RockMemoryCache.Default;
            cache.Remove( CACHE_KEY );
        }
    }

    public static partial class ReservationWorkflowTriggerExtensionMethods
    {
        public static ReservationWorkflowTrigger Clone( this ReservationWorkflowTrigger source, bool deepCopy )
        {
            if ( deepCopy )
            {
                return source.Clone() as ReservationWorkflowTrigger;
            }
            else
            {
                var target = new ReservationWorkflowTrigger();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this ReservationWorkflowTrigger target, ReservationWorkflowTrigger source )
        {
            target.Id = source.Id;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.QualifierValue = source.QualifierValue;
            target.TriggerType = source.TriggerType;
            target.WorkflowTypeId = source.WorkflowTypeId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;
        }
    }

}
