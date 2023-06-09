﻿using MediatR;
using TaskManager.Application.DTOs.Projects;

namespace TaskManager.Application.Features.Projects.Requests.Queries
{
    public class GetProjectDetailRequest : IRequest<ProjectDto>
    {
        public int Id { get; set; }
    }
}