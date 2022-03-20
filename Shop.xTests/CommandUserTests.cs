using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Store.BusinessLogic.Commands.UserCommands;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using Xunit;

namespace Shop.xTests
{
    public class CommandUserTests
    {
        private readonly Mock<IStoreDbContext> _context;
        private readonly Mock<IUserStore<User>> _userManager;
        public CommandUserTests()
        {
            _context = new Mock<IStoreDbContext>();
            _userManager = new Mock<IUserStore<User>>();
        }

        [Fact]
        public async Task CreateUserHandler_Success()
        {
            //arrange
            var fixture = new CreateUser.Command("pavel", "pavell@gmail.com", "papsdadk21xi", "Poland", "+3753391822183");
            var handler = new CreateUser.Handler(_context.Object,_userManager.Object);
            //act
            var result = await handler.Handle(fixture, new CancellationToken());

        }
    }
}
