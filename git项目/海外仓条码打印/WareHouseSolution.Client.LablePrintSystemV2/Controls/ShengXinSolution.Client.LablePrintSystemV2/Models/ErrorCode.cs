using System.ComponentModel;

namespace ShengXinSolution.Client.LablePrintSystemV2.Models
{
    class ErrorCode
    {
        public enum StatusCode
        {
            /// <summary>
            /// 0 正常
            /// </summary>
            [Description("正常")]
            SucceessRequest = 0,

            /// <summary>
            /// 0 插入失败
            /// </summary>
            [Description("插入失败")]
            InsertFailure = 0,

            /// <summary>
            /// 0 插入成功
            /// </summary>
            [Description("插入成功")]
            InsertSuccess = 0,

            /// <summary>
            /// 0 更新失败
            /// </summary>
            [Description("更新失败")]
            UpdateFailure = 0,

            /// <summary>
            /// 0 更新成功
            /// </summary>
            [Description("更新成功")]
            UpdateSuccess = 0,

            /// <summary>
            /// 0 删除失败
            /// </summary>
            [Description("删除失败")]
            DeleteFailure = 0,

            /// <summary>
            /// 0 删除成功
            /// </summary>
            [Description("删除成功")]
            DeleteSuccess = 0,

            /// <summary>
            /// -1 服务器错误
            /// </summary>
            [Description("十分抱歉.服务器出错啦.%>_<%.请致电开发商睿博软件0631-5970778")]
            DefaultError = -1,

            /// <summary>
            /// -204 无返回结果
            /// </summary>
            [Description("无返回结果")]
            NoResultError = -204,

            /// <summary>
            /// -301 参数格式错误
            /// </summary>
            [Description("参数格式错误")]
            ParamFormartError = -301,

            /// <summary>
            /// -302 参数转换错误
            /// </summary>
            [Description("参数转换错误")]
            ParamConvertError = -302,

            /// <summary>
            /// -400 请求无效
            /// </summary>
            [Description("参数错误,请求无效")]
            BadRequestError = -400,

            /// <summary>
            /// -401 用户未授权
            /// </summary>
            [Description("用户未授权")]
            UnauthorizedError = -401,

            /// <summary>
            /// -403 用户权限不足
            /// </summary>
            [Description("用户权限不足")]
            ForbiddenError = -403,

            /// <summary>
            /// -404 未找到资源
            /// </summary>
            [Description("未找到资源")]
            NotFoundError = -404,

            /// <summary>
            /// -405 请求方法不支持
            /// </summary>
            [Description("请求方法不支持")]
            MethodNotAllowedError = -405,

            /// <summary>
            /// -408 请求超时
            /// </summary>
            [Description("请求超时")]
            RequestTimeoutError = -408,

            /// <summary>
            /// -412 不满足参数条件
            /// </summary>
            [Description("不满足参数条件")]
            PreconditionFailedError = -412,

            /// <summary>
            /// -413 请求实体过大
            /// </summary>
            [Description("请求实体过大")]
            RequestEntityTooLargError = -413,

            /// <summary>
            /// -414 请求URI过长
            /// </summary>
            [Description("请求URI过长")]
            RequestUriTooLongError = -414,

            /// <summary>
            /// -600 数据库默认错误
            /// </summary>
            [Description("数据库错误")]
            SqlDefaultError = -600,

            /// <summary>
            /// -601 主键冲突
            /// </summary>
            [Description("主键冲突")]
            SqlPrimaryKeyConflictError = -601,

            /// <summary>
            /// -602 外键约束
            /// </summary>
            [Description("外键约束")]
            SqlForeignKeyConstraintError = -602,

            /// <summary>
            /// -603 数据库超时
            /// </summary>
            [Description("数据库超时")]
            SqlDatabaseTimeoutError = -603,

            /// <summary>
            /// -604 SQL语法错误
            /// </summary>
            [Description("SQL语法错误")]
            SqlSyntaxError = -604,

            /// <summary>
            /// -700 IO默认错误
            /// </summary>
            [Description("IO错误")]
            IoDefaultError = -700,

            /// <summary>
            /// -701 未找到文件或路径
            /// </summary>
            [Description("未找到文件或路径")]
            IoDirNotFoundError = -701,

            /// <summary>
            /// -702 无法创建文件夹
            /// </summary>
            [Description("无法创建文件夹")]
            IoCanNotCreateDirError = -702,

            /// <summary>
            /// -703 关闭文件流错误
            /// </summary>
            [Description("关闭文件流错误")]
            IoEndOfStreamError = -703,

            /// <summary>
            /// -704 文件加载出错
            /// </summary>
            [Description("文件加载出错")]
            IoFileLoadError = -704,

            /// <summary>
            /// -705 路径或文件名过长
            /// </summary>
            [Description("路径或文件名过长")]
            IoPathTooLongError = -705,

            /// <summary>
            /// -800 JSON默认错误
            /// </summary>
            [Description("JSON错误")]
            JsonDefaultError = -800,

            /// <summary>
            /// -801 JSON序列化错误
            /// </summary>
            [Description("JSON序列化错误")]
            JsonSerializeError = -801,

            /// <summary>
            /// -802 JSON反序列化错误
            /// </summary>
            [Description("JSON反序列化错误")]
            JsonDeserializeError = -802,

        }
    }
}
