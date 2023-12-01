namespace Npgsql;

public static class NpgsqlDataReaderExtension {
    public static object? get(this NpgsqlDataReader reader,string fieldName) {
        object? value = reader[fieldName] is DBNull?null:reader[fieldName];
        return value;
    }
}