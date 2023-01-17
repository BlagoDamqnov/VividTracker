﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VividTracker.Business.Services;
using VividTracker.Business.Services.Interfaces;
using VividTracker.Data.Models;
using VividTracker.Models;
using VividTracker.ViewModels;

namespace VividTracker.Controllers
{
    [ApiController]
    public class TrackersController : ControllerBase
    {
        private readonly ITrackingGroupsService _trackingGroupsService;
        private readonly ITenantsService _tenantsService;
        public TrackersController(ITrackingGroupsService trackingGroupsService,ITenantsService tenantsService)
        {
            _trackingGroupsService = trackingGroupsService;
            _tenantsService = tenantsService;
        }

        [HttpGet]
        [Route("api/trackers/{tenantId}")]
        public async Task<IActionResult> GetTrackingGroupsByTenantId([FromRoute] int tenantId)
         {
            var trackingGroups = await _trackingGroupsService.GetTrackingGroupsByTenantId(tenantId);

            if (!trackingGroups.Any())
            {
                return BadRequest("No exist tracking groups!");
            }
            return Ok(trackingGroups);
        }
        [HttpPatch]
        [Route("api/trackingGroup/edit/{trackingGroupId}")]
        public async Task<IActionResult> EditTrackingGroupName([FromRoute] int trackingGroupId, [FromBody] TrackerRequestModel trackerRequestModel)
        {
            var tracker = trackerRequestModel.ToTrackerModel(trackingGroupId);
            var result =  await _trackingGroupsService.UpdateTrackingGroupName(tracker);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error!");
        }
        [HttpPost]
        [Route("api/trackingGroup/create/{tenandId}")]
        public async Task<IActionResult> CreateTrackingGroup([FromRoute] int tenandId, [FromBody] TrackingGroupRequestModel trackingGroupRequestModel)
        {
            var tenant = await _tenantsService.GetTenantByIdAsync(tenandId);

            var tracker = trackingGroupRequestModel.ToCreateTrackingGroup(tenant);
            var result = await _trackingGroupsService.CreateTrackingGroup(tracker);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error!");
        }
    }
}
