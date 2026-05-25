using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Context.Dtos;
using NexoCPM.Application.Curriculum.Dtos;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Curriculum
{
    public class SubTopicRepository : ISubTopicRepository
    {
        private readonly ApplicationDbContext _context;

        public SubTopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<SubTopicDetailDto>> GetSubTopicDetailPagedAsync(
            string subtopicSlug, int page, int pageSize)
        {
            var subtopic = await _context.SubTopics
                .AsNoTracking()
                .Where(st => st.Slug == subtopicSlug && st.IsActive && !st.IsDeleted)
                .Select(st => new { st.Id, st.TopicId })
                .FirstOrDefaultAsync();

            if (subtopic is null)
                return new PaginatedResult<SubTopicDetailDto>();

            var topicId = subtopic.TopicId;

            var totalCount = await _context.SubTopics
                .AsNoTracking()
                .CountAsync(st => st.TopicId == topicId && st.IsActive && !st.IsDeleted);

            var items = await _context.SubTopics
                .AsNoTracking()
                .Where(st => st.TopicId == topicId && st.IsActive && !st.IsDeleted && st.Id == subtopic.Id)
                .OrderBy(st => st.OrderIndex)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(st => new
                {
                    st.Id,
                    st.Code,
                    st.Slug,
                    st.Description,
                    st.OrderIndex,
                    st.TopicId,
                    MicroTopics = st.MicroTopics
                        .Where(mt => mt.IsActive && !mt.IsDeleted)
                        .OrderBy(mt => mt.OrderIndex)
                        .Select(mt => new MicroTopicDto
                        {
                            Id = mt.Id,
                            Code = mt.Code,
                            Slug = mt.Slug,
                            Description = mt.Description,
                            OrderIndex = mt.OrderIndex
                        })
                        .ToList(),
                    Competence = st.Competence != null ? new
                    {
                        st.Competence.Id,
                        st.Competence.Code,
                        st.Competence.Name,
                        Abilities = st.Competence.Abilities
                            .Select(a => new AbilityDto
                            {
                                Id = a.Id,
                                Code = a.Code,
                                Name = a.Name,
                                Description = a.Description ?? string.Empty
                            })
                            .ToList(),
                        Levels = st.Competence.CompetenceLevels
                            .Select(cl => new CompetenceLevelDto
                            {
                                Id = cl.Id,
                                LevelNumber = cl.LevelNumber,
                                Description = cl.Description ?? string.Empty
                            })
                            .ToList()
                    } : null,
                    MinLevel = st.Topic.SyllabusUnit.Syllabus.MinCompetenceLevel,
                    MaxLevel = st.Topic.SyllabusUnit.Syllabus.MaxCompetencLevel
                })
                .ToListAsync();

            var detailItems = items.Select(i =>
            {
                var detail = new SubTopicDetailDto
                {
                    SubTopic = new SubTopicDto
                    {
                        Id = i.Id,
                        Code = i.Code,
                        Slug = i.Slug,
                        Description = i.Description,
                        OrderIndex = i.OrderIndex,
                        TopicId = i.TopicId
                    },
                    MicroTopics = i.MicroTopics,
                    TopicId = i.TopicId
                };

                if (i.Competence is not null)
                {
                    var filteredLevels = i.Competence.Levels
                        .Where(cl => cl.LevelNumber >= i.MinLevel && cl.LevelNumber <= i.MaxLevel)
                        .ToList();

                    detail.Competence = new CompetenceDto
                    {
                        Id = i.Competence.Id,
                        Code = i.Competence.Code,
                        Name = i.Competence.Name,
                        Abilities = i.Competence.Abilities,
                        CompetenceLevels = filteredLevels
                    };
                }

                return detail;
            }).ToList();

            return new PaginatedResult<SubTopicDetailDto>
            {
                Items = detailItems,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
