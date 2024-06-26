﻿using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Core.Models.Searches;

namespace HRMS.Controllers;

public class ChatController(IMessageRepository messageRepository) : BaseController<Message, MessageSearch>(messageRepository) { }