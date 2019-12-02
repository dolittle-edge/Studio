using System;
using System.Collections.Generic;
using Dolittle.Events.Processing;
using Events.Installations;
using MongoDB.Driver;

namespace Read.Installations
{
    public class SiteStatusEventProcessors: ICanProcessEvents
    {
        readonly IMongoCollection<SiteStatus> _siteStatusCollection;

        public SiteStatusEventProcessors(IMongoCollection<SiteStatus> siteStatusCollection)
        {
            _siteStatusCollection = siteStatusCollection;
        }

        [EventProcessor("f37344c2-edef-4bfa-a077-98ebfcdf3dc9")]
        public void Process(SiteRegistered @event)
        {
            var status = new SiteStatus
            {
                Id = @event.SiteId,
                Name = @event.Name,
                LastSeenNodes = new Dictionary<string,DateTimeOffset>()
            };
            _siteStatusCollection.InsertOne(status);
        }

        [EventProcessor("abced9ac-1987-4fd9-91b2-3ae306d663fb")]
        public void Process(NodeRegisteredWithInstallation @event)
        {
            var siteStatus = _siteStatusCollection.Find(_ => _.Id == @event.SiteId).FirstOrDefault();
            siteStatus.TotalNodes ++;
            _siteStatusCollection.ReplaceOne(_ => _.Id == @event.SiteId, siteStatus, new UpdateOptions { IsUpsert = true });
        }
    }
}