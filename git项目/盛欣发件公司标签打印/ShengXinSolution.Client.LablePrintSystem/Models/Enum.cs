using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShengXinSolution.Client.LablePrintSystem.Models
{
    class Enum
    {
        public enum statusCode
        {
            /// <summary>
            /// 0 正常
            /// </summary>
            [Description("正常")]
            SUCCEESS_REQUEST = 0,

            /// <summary>
            /// 0 插入失败
            /// </summary>
            [Description("插入失败")]
            INSERT_FAILURE = 0,

            /// <summary>
            /// 0 插入成功
            /// </summary>
            [Description("插入成功")]
            INSERT_SUCCESS = 0,

            /// <summary>
            /// 0 更新失败
            /// </summary>
            [Description("更新失败")]
            UPDATE_FAILURE = 0,

            /// <summary>
            /// 0 更新成功
            /// </summary>
            [Description("更新成功")]
            UPDATE_SUCCESS = 0,

            /// <summary>
            /// 0 删除失败
            /// </summary>
            [Description("删除失败")]
            DELETE_FAILURE = 0,

            /// <summary>
            /// 0 删除成功
            /// </summary>
            [Description("删除成功")]
            DELETE_SUCCESS = 0,

            /// <summary>
            /// -1 服务器错误
            /// </summary>
            [Description("十分抱歉.服务器出错啦.%>_<%.请致电开发商睿博软件0631-5970778")]
            DEFAULT_ERROR = -1,

            /// <summary>
            /// -204 无返回结果
            /// </summary>
            [Description("无返回结果")]
            NO_RESULT_ERROR = -204,

            /// <summary>
            /// -301 参数格式错误
            /// </summary>
            [Description("参数格式错误")]
            PARAM_FORMART_ERROR = -301,

            /// <summary>
            /// -302 参数转换错误
            /// </summary>
            [Description("参数转换错误")]
            PARAM_CONVERT_ERROR = -302,

            /// <summary>
            /// -400 请求无效
            /// </summary>
            [Description("参数错误,请求无效")]
            BAD_REQUEST_ERROR = -400,

            /// <summary>
            /// -401 用户未授权
            /// </summary>
            [Description("用户未授权")]
            UNAUTHORIZED_ERROR = -401,

            /// <summary>
            /// -403 用户权限不足
            /// </summary>
            [Description("用户权限不足")]
            FORBIDDEN_ERROR = -403,

            /// <summary>
            /// -404 未找到资源
            /// </summary>
            [Description("未找到资源")]
            NOT_FOUND_ERROR = -404,

            /// <summary>
            /// -405 请求方法不支持
            /// </summary>
            [Description("请求方法不支持")]
            METHOD_NOT_ALLOWED_ERROR = -405,

            /// <summary>
            /// -408 请求超时
            /// </summary>
            [Description("请求超时")]
            REQUEST_TIMEOUT_ERROR = -408,

            /// <summary>
            /// -412 不满足参数条件
            /// </summary>
            [Description("不满足参数条件")]
            PRECONDITION_FAILED_ERROR = -412,

            /// <summary>
            /// -413 请求实体过大
            /// </summary>
            [Description("请求实体过大")]
            REQUEST_ENTITY_TOO_LARG_ERROR = -413,

            /// <summary>
            /// -414 请求URI过长
            /// </summary>
            [Description("请求URI过长")]
            REQUEST_URI_TOO_LONG_ERROR = -414,

            /// <summary>
            /// -600 数据库默认错误
            /// </summary>
            [Description("数据库错误")]
            SQL_DEFAULT_ERROR = -600,

            /// <summary>
            /// -601 主键冲突
            /// </summary>
            [Description("主键冲突")]
            SQL_PRIMARY_KEY_CONFLICT_ERROR = -601,

            /// <summary>
            /// -602 外键约束
            /// </summary>
            [Description("外键约束")]
            SQL_FOREIGN_KEY_CONSTRAINT_ERROR = -602,

            /// <summary>
            /// -603 数据库超时
            /// </summary>
            [Description("数据库超时")]
            SQL_DATABASE_TIMEOUT_ERROR = -603,

            /// <summary>
            /// -604 SQL语法错误
            /// </summary>
            [Description("SQL语法错误")]
            SQL_SYNTAX_ERROR = -604,

            /// <summary>
            /// -700 IO默认错误
            /// </summary>
            [Description("IO错误")]
            IO_DEFAULT_ERROR = -700,

            /// <summary>
            /// -701 未找到文件或路径
            /// </summary>
            [Description("未找到文件或路径")]
            IO_DIR_NOT_FOUND_ERROR = -701,

            /// <summary>
            /// -702 无法创建文件夹
            /// </summary>
            [Description("无法创建文件夹")]
            IO_CAN_NOT_CREATE_DIR_ERROR = -702,

            /// <summary>
            /// -703 关闭文件流错误
            /// </summary>
            [Description("关闭文件流错误")]
            IO_END_OF_STREAM_ERROR = -703,

            /// <summary>
            /// -704 文件加载出错
            /// </summary>
            [Description("文件加载出错")]
            IO_FILE_LOAD_ERROR = -704,

            /// <summary>
            /// -705 路径或文件名过长
            /// </summary>
            [Description("路径或文件名过长")]
            IO_PATH_TOO_LONG_ERROR = -705,

            /// <summary>
            /// -800 JSON默认错误
            /// </summary>
            [Description("JSON错误")]
            JSON_DEFAULT_ERROR = -800,

            /// <summary>
            /// -801 JSON序列化错误
            /// </summary>
            [Description("JSON序列化错误")]
            JSON_SERIALIZE_ERROR = -801,

            /// <summary>
            /// -802 JSON反序列化错误
            /// </summary>
            [Description("JSON反序列化错误")]
            JSON_DESERIALIZE_ERROR = -802,

        }
    }
}
