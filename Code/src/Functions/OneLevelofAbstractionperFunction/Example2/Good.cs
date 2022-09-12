namespace OneLevelofAbstractionperFunction.Example2;

public class Good
{
    private readonly DateHelper _dateHelper = new();

    public List<ResultDto> buildResult(List<ResultEntity> resultSet)
    {
        return resultSet.Select(toDto).ToList();
    }

    private ResultDto toDto(ResultEntity entity)
    {
        var dto = new ResultDto();
        dto.setShoeSize(entity.getShoeSize());
        dto.setNumberOfEarthWorms(entity.getNumberOfEarthWorms());
        dto.setAge(_dateHelper.computeAge(entity.getBirthday()));
        return dto;
    }
}