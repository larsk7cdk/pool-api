//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Profile = bbob.domain.Models.Profile.Profile;

//namespace pool_api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProfileController : ControllerBase
//    {
//        private readonly IProfileFacade profileFacade;
//        private readonly IDisclaimerService disclaimerService;

//        public ProfileController(IProfileFacade profileFacade, IDisclaimerService disclaimerService)
//        {
//            this.profileFacade = profileFacade;
//            this.disclaimerService = disclaimerService;
//        }

//        [HttpGet]
//        [Route("{profileId}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profile))]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        public async Task<ActionResult<Profile>> GetProfile([FromRoute] Guid profileId)
//        {
//            var profile = await profileFacade.GetProfile(profileId);

//            if (profile == null)
//                return NoContent();

//            //Todo: create user check - must be current user

//            return Ok(profile);
//        }

//        [HttpPost]
//        [Route("")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profile))]
//        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Profile))]
//        public async Task<ActionResult> SaveProfile([FromBody] Profile profile)
//        {
//            var profileId = profile.Id;

//            //Todo: create user check - must be current user

//            profile = await profileFacade.SaveProfile(profile);

//            if (profileId != Guid.Empty)
//                return Ok(profile);
//            else
//                return CreatedAtAction(nameof(GetProfile), new { userId = profile.Id }, profile);
//        }

//        [HttpGet]
//        [Route("{profileId}/disclaimer")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDisclaimer))]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        public async Task<ActionResult<ProfileDisclaimer>> GetProfileDisclaimerAccept([FromRoute] Guid profileId)
//        {
//            //Todo: create user check - must be current user
//            var profileDisclaimerAccept = await profileFacade.GetLatestProfileDisclaimerAccept(profileId);

//            if (profileDisclaimerAccept == null)
//                return NoContent();

//            var profileDisclaimer = await ConvertProfileDisclaimerAccept(profileDisclaimerAccept);

//            return Ok(profileDisclaimer);
//        }

//        private async Task<ProfileDisclaimer> ConvertProfileDisclaimerAccept(ProfileDisclaimerAccept profileDisclaimerAccept)
//        {
//            var latestDisclaimer = await disclaimerService.GetLatestDisclaimer();
//            var isUpToDate = profileDisclaimerAccept.DisclaimerId == latestDisclaimer.Id;

//            var profileDisclaimer = new ProfileDisclaimer
//            {
//                ProfileId = profileDisclaimerAccept.ProfileId,
//                DisclaimerId = profileDisclaimerAccept.DisclaimerId,
//                Date = profileDisclaimerAccept.DateCreated,
//                Accepted = profileDisclaimerAccept.Accepted,
//                IsUpToDate = isUpToDate
//            };
//            return profileDisclaimer;
//        }

//        [HttpPost]
//        [Route("{profileId}/disclaimer")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public async Task<ActionResult> SaveProfileDisclaimerAccept([FromRoute] Guid profileId, [FromBody] ProfileDisclaimerAcceptSaveRequest request)
//        {
//            //Todo: create user check - must be current user
//            await profileFacade.SaveProfileDisclaimerAccept(profileId, request.DisclaimerId, request.Accepted);

//            return Ok();
//        }
//    }
//}