﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Http;
using Litdev.MongoDB;

namespace Litdev.Service.Controllers
{
    public class ShiDaiController : ApiController
    { 
        /// <summary>
        /// 注册机器
        /// </summary>
        /// <returns></returns>
        [Route("api/v1/sd/machine/reg")]
        [HttpPost]
        public APIResponseEntity<string> RegMachine([FromBody]Models.ModelRegMachine req)
        {
            APIResponseEntity<string> response_entity = new APIResponseEntity<string>();

            if (string.IsNullOrWhiteSpace(req.mach_id))
            {
                response_entity.msgbox = "机器码不能为空";
                return response_entity;
            }

            bool is_ok = new DALMachine().AddMachine(req.mach_id, req.remark);
            if (is_ok)
            {
                response_entity.msg = 1;
                response_entity.msgbox = "注册成功";
            }
            else
            {
                response_entity.msgbox = "注册失败,可能已经注册过了";
            }
            return response_entity;
        }

        /// <summary>
        /// 获取用户队列
        /// </summary>
        /// <param name="top">多少条</param>
        /// <param name="mach_id">机器码</param>
        /// <returns></returns>
        [Route("api/v1/sd/queue/list")]
        [HttpGet]
        public APIResponseEntity<List<EntityQueue>> GetTopQueue(int top, string mach_id)
        {
            APIResponseEntity<List<EntityQueue>> response_entity = new APIResponseEntity<List<EntityQueue>>();
            response_entity.data = new DALQueue().GetTopQueueList(top, mach_id);
            response_entity.msg = 1;
            response_entity.msgbox = "ok";
            return response_entity;
        }

        /// <summary>
        /// 队列任务完成
        /// </summary>
        /// <param name="id">机器码</param>
        /// <returns></returns>
        [Route("api/v1/sd/queue/done")]
        [HttpGet]
        public APIResponseEntity<string> UserDone(string id)
        {
            APIResponseEntity<string> response_entity = new APIResponseEntity<string>();
            bool is_ok = new DALQueue().UserDone(id);
            if (is_ok)
            {
                response_entity.msg = 1;
                response_entity.msgbox = "ok";
            }
            else
                response_entity.msgbox = "error";
            return response_entity;
        }
    }
}
