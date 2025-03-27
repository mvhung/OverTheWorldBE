using AutoMapper;
using LearningVocab.DTO;
using LearningVocab.Interface;
using LearningVocab.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningVocab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            var users = await _userService.GetUsers();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return _mapper.Map<UserModel>(user);
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody] CreateUserModel createUserModel)
        {
            if (createUserModel == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(createUserModel);
            var createdUser = await _userService.AddUser(user);
            var userModel = _mapper.Map<UserModel>(createdUser);

            return CreatedAtAction(nameof(Get), new { id = userModel.UserId }, userModel);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserModel userModel)
        {
            if (userModel == null || userModel.UserId != id)
            {
                return BadRequest();
            }

            var existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(userModel);
            await _userService.UpdateUser(user);

            return NoContent();
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
