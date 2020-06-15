using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrontendAPI.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private ILogger<DataController> Logger { get; }

        private ChannelContext Ctx { get; }

        public DataController(ILogger<DataController> logger, ChannelContext ctx)
        {
            Logger = logger;
            Ctx = ctx;
        }
        [HttpGet]
        [Route("GetChannelSystems")]
        public List<ChannelSystem> GetChannelSystems()
        {
            return Ctx.ChannelSystems.ToList();
        }
        [HttpGet]
        [Route("GetChannelSystem/{id}")]
        public ChannelSystem GetChannelSystem(Guid id)
        {
            return Ctx.ChannelSystems.FirstOrDefault(c => c.ID == id);
        }
        [HttpGet]
        [Route("ChannelSystem/{id}/Channels")]
        public List<Channel> GetChannelBySystem(Guid id)
        {
            return Ctx.ChannelSystems.FirstOrDefault(c => c.ID == id).Channels.ToList();
        }
       
        [HttpGet]
        [Route("Channel/{id}")]
        public Channel GetChannel(Guid id)
        {
            return Ctx.Channels.FirstOrDefault(c => c.ChannelId == id);
        }

        [HttpGet]
        [Route("Contact/{id}")]
        public Contact GetContact(Guid id)
        {
            return Ctx.Contacts.FirstOrDefault(c => c.ID == id);
        }

        [HttpGet]
        [Route("ChannelMessage/Transaction/{id}")]
        public List<ChannelMessage> GetChannelMessageByTransaction(Guid id)
        {
                return Ctx.ChannelMessages
                        .Where(p => p.TransactionID == id)
                        .ToList();
        }
        [HttpGet]
        [Route("ChannelMessage/{page}/{size}")]
        public List<ChannelMessage> GetChannelMessage(int page,int size)
        {
            return Ctx.ChannelMessages
                    .Skip(page*size).Take(size)
                    .ToList();
        }

        [HttpGet]
        [Route("ChannelMessage/source/{id}")]
        public List<ChannelMessage> GetChannelMessageBySource(Guid id)
        {
            return Ctx.ChannelMessages.Where(p=> p.SourceChannelID == id)
                    .ToList();
        }
        [HttpGet]
        [Route("ChannelMessage/target/{id}")]
        public List<ChannelMessage> GetChannelMessageByTarget(Guid id)
        {
            return Ctx.ChannelMessages.Where(p => p.TargetChannelID == id)
                    .ToList();
        }


    }
}