namespace OneLevelofAbstractionperFunction.Example2;

public class Bad
{
    private readonly DateHelper _dateHelper = new();

    public List<ResultDto> buildResult(List<ResultEntity> resultSet)
    {
        var result = new List<ResultDto>();

        foreach (var entity in resultSet)
        {
            var dto = new ResultDto();
            dto.setShoeSize(entity.getShoeSize());
            dto.setNumberOfEarthWorms(entity.getNumberOfEarthWorms());
            dto.setAge(_dateHelper.computeAge(entity.getBirthday()));
            result.Add(dto);
        }

        return result;
    }
}