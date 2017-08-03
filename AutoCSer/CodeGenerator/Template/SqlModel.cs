﻿using System;

namespace AutoCSer.CodeGenerator.Template
{
    class SqlModel : Pub
    {
        #region NOTE
        const bool IsCreateEventCache = false;
        const int CountTypeNumber = 0;
        const int Timeout = 0;
        #endregion NOTE
        #region PART CLASS
        #region IF Attribute.IsDefaultSerialize
        [AutoCSer.Json.Serialize]
        [AutoCSer.Json.Parse]
        [AutoCSer.BinarySerialize.Serialize(IsReferenceMember = false/*NOT:IsDefaultSerializeIsMemberMap*/, IsMemberMap = false/*NOT:IsDefaultSerializeIsMemberMap*/)]
        #endregion IF Attribute.IsDefaultSerialize
        /*NOTE*/
        public partial class /*NOTE*/@TypeNameDefinition
        {
            /// <summary>
            /// 数据库表格模型
            /// </summary>
            /// <typeparam name="tableType">表格映射类型</typeparam>
            #region IF IsMemberCache
            /// <typeparam name="memberCacheType">成员绑定缓存类型</typeparam>
            #endregion IF IsMemberCache
            public abstract class SqlModel<tableType/*IF:IsMemberCache*/, memberCacheType/*IF:IsMemberCache*/> : @Type.FullName/*IF:Attribute.LogServerName*/, AutoCSer.Sql.LogStream.IMemberMapValueLink<tableType>/*IF:Attribute.LogServerName*/
                where tableType : SqlModel<tableType/*IF:IsMemberCache*/, memberCacheType/*IF:IsMemberCache*/>
                #region IF IsMemberCache
                where memberCacheType : /*AT:MemberCacheBaseType*//*IF:CounterCacheType=CreateIdentityCounterMemberQueue*/AutoCSer.Sql.Cache.Whole.MemberCacheCounter<tableType, memberCacheType>/*IF:CounterCacheType=CreateIdentityCounterMemberQueue*/
                #endregion IF IsMemberCache
            {
                /// <summary>
                /// SQL表格操作工具
                /// </summary>
                protected static readonly AutoCSer.Sql.Table<tableType, @Type.FullName/*IF:PrimaryKeys.Length*/, @PrimaryKeyType/*IF:PrimaryKeys.Length*/> sqlTable = AutoCSer.Sql.Table<tableType, @Type.FullName/*IF:PrimaryKeys.Length*/, @PrimaryKeyType/*IF:PrimaryKeys.Length*/>.Get(@IsCreateEventCache);
                private static bool isSqlLoaded;
                /// <summary>
                /// 等待数据初始化完成
                /// </summary>
                public static void WaitSqlLoaded()
                {
                    if (!isSqlLoaded)
                    {
                        sqlTable/**/.WaitLoad();
                        isSqlLoaded = true;
                    }
                }
                #region IF IsEventCacheLoaded
                private static bool isEventCacheLoaded;
                /// <summary>
                /// 等待数据事件缓存数据初始化完成
                /// </summary>
                public static void WaitEventCacheLoaded()
                {
                    if (!isEventCacheLoaded)
                    {
                        #region IF IsCreateEventCache
                        sqlTable/**/.WaitCreateCache();
                        #endregion IF IsCreateEventCache
                        #region NOT IsCreateEventCache
                        if (@IdentityArrayCacheName == null) throw new NullReferenceException(AutoCSer.Extension.TypeExtension.fullName(typeof(tableType)) + ".@IdentityArrayCacheName is null");
                        #endregion NOT IsCreateEventCache
                        isEventCacheLoaded = true;
                    }
                }
                #endregion IF IsEventCacheLoaded
                #region IF IsSqlLoaded
                /// <summary>
                /// 数据加载完成
                /// </summary>
                #region IF IsSqlCacheLoaded
                /// <param name="onInserted">添加记录事件</param>
                /// <param name="onUpdated">更新记录事件</param>
                /// <param name="onDeleted">删除记录事件</param>
                #region IF Attribute.LogServerName
                /// <param name="isMemberMap">是否支持成员位图</param>
                #endregion IF Attribute.LogServerName
                #endregion IF IsSqlCacheLoaded
                protected static void sqlLoaded(/*IF:IsSqlCacheLoaded*/Action<tableType> onInserted = null, Action</*IF:Attribute.IsLoadedCache*/tableType, /*IF:Attribute.IsLoadedCache*/tableType, tableType, AutoCSer.Metadata.MemberMap<@Type.FullName>> onUpdated = null, Action<tableType> onDeleted = null/*IF:Attribute.LogServerName*/, bool isMemberMap = true/*IF:Attribute.LogServerName*//*IF:IsSqlCacheLoaded*/)
                {
                    #region IF IsSqlCacheLoaded
                    #region IF Attribute.LogServerName
                    sqlStream/**/.Set(@IdentityArrayCacheName, isMemberMap);
                    #endregion IF Attribute.LogServerName
                    #region IF Attribute.IsLoadedCache
                    @IdentityArrayCacheName/**/.Loaded(onInserted, onUpdated, onDeleted/*IF:SqlStreamTypeCount*/, false/*IF:SqlStreamTypeCount*/);
                    #endregion IF Attribute.IsLoadedCache
                    #region NOT Attribute.IsLoadedCache
                    sqlTable/**/.CacheLoaded(onInserted, /*NOTE*/(Action<tableType, tableType, AutoCSer.Metadata.MemberMap<@Type.FullName>>)(object)/*NOTE*/onUpdated, onDeleted/*IF:SqlStreamTypeCount*/, false/*IF:SqlStreamTypeCount*/);
                    #endregion NOT Attribute.IsLoadedCache
                    #endregion IF IsSqlCacheLoaded
                    #region IF SqlStreamTypeCount
                    sqlTable/**/.AddLogStreamLoadedType(SqlLogMembers._LoadCount_/*LOOP:SqlStreamCountTypes*/, new AutoCSer.Sql.LogStream.LoadedType(typeof(@SqlStreamCountType.FullName), @CountTypeNumber)/*LOOP:SqlStreamCountTypes*/);
                    #endregion IF SqlStreamTypeCount
                }
                #endregion IF IsSqlLoaded
                #region IF CacheType=IdentityArray
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static readonly AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, tableType> @IdentityArrayCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, tableType>(sqlTable, null);
                #endregion IF CacheType=IdentityArray
                #region IF CacheType=IdentityTree
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static readonly AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, tableType> @IdentityTreeCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, tableType>(sqlTable, null);
                #endregion IF CacheType=IdentityTree
                #region IF CacheType=PrimaryKey
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static readonly AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, tableType, @PrimaryKeyType> @PrimaryKeyCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, tableType, @PrimaryKeyType>(sqlTable, null);
                #endregion IF CacheType=PrimaryKey
                #region IF CacheType=PrimaryKeyArray
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static readonly AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, tableType, @PrimaryKeyType> @PrimaryKeyArrayCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, tableType, @PrimaryKeyType>(sqlTable, null);
                #endregion IF CacheType=PrimaryKeyArray

                #region IF CacheType=CreateIdentityArray
                #region IF IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, memberCacheType> @CreateIdentityArrayMemberCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <typeparam name="memberCacheType"></typeparam>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="isReset">是否初始化事件与数据</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, memberCacheType> createCache(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, int group = 0, int baseIdentity = 0, bool isReset = true)
                {
                    if (sqlTable == null) return null;
                    @CreateIdentityArrayMemberCacheName = new AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, memberCacheType>(sqlTable, memberCache, group, baseIdentity, isReset);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreateIdentityArrayMemberCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    #region IF CounterMembers.Length
                    createCounter(@CreateIdentityArrayMemberCacheName);
                    #endregion IF CounterMembers.Length
                    return @CreateIdentityArrayMemberCacheName;
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, tableType> @CreateIdentityArrayCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="group">数据分组</param>
                /// <param name="isReset">是否初始化事件与数据</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, tableType> createCache(int group = 0, int baseIdentity = 0, bool isReset = true)
                {
                    if (sqlTable == null) return null;
                    @CreateIdentityArrayCacheName = new AutoCSer.Sql.Cache.Whole.Event.IdentityArray<tableType, @Type.FullName, tableType>(sqlTable, null, group, baseIdentity, isReset);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreateIdentityArrayCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreateIdentityArrayCacheName;
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreateIdentityArray
                #region IF CacheType=CreateIdentityArrayWhere
                #region IF IsMemberCache
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="isReset">是否初始化事件与数据</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhere<tableType, @Type.FullName, memberCacheType> createCache(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, Func<tableType, bool> isValue, int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    return new AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhere<tableType, @Type.FullName, memberCacheType>(sqlTable, memberCache, isValue, group, baseIdentity);
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="isValue">数据匹配器,必须保证更新数据的匹配一致性</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhere<tableType, @Type.FullName, tableType> createCache(Func<tableType, bool> isValue, int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    return new AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhere<tableType, @Type.FullName, tableType>(sqlTable, null, isValue, group, baseIdentity);
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreateIdentityArrayWhere
                #region IF CacheType=CreateIdentityArrayWhereExpression
                #region IF IsMemberCache
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="isReset">是否初始化事件与数据</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhereExpression<tableType, @Type.FullName, memberCacheType> createCache(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, System.Linq.Expressions.Expression<Func<@Type.FullName, bool>> isValue, int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    return new AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhereExpression<tableType, @Type.FullName, memberCacheType>(sqlTable, memberCache, isValue, group, baseIdentity);
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="isValue">数据匹配器,必须保证更新数据的匹配一致性</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhereExpression<tableType, @Type.FullName, tableType> createCache(System.Linq.Expressions.Expression<Func<@Type.FullName, bool>> isValue, int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    return new AutoCSer.Sql.Cache.Whole.Event.IdentityArrayWhereExpression<tableType, @Type.FullName, tableType>(sqlTable, null, isValue, group, baseIdentity);
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreateIdentityArrayWhereExpression
                #region IF CacheType=CreateIdentityTree
                #region IF IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, memberCacheType> @CreateIdentityTreeMemberCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, memberCacheType> createCache(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    @CreateIdentityTreeMemberCacheName = new AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, memberCacheType>(sqlTable, memberCache, group, baseIdentity);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreateIdentityTreeMemberCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    #region IF CounterMembers.Length
                    createCounter(@CreateIdentityTreeMemberCacheName);
                    #endregion IF CounterMembers.Length
                    return @CreateIdentityTreeMemberCacheName;
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, tableType> @CreateIdentityTreeCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="baseIdentity">基础ID</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, tableType> createCache(int group = 0, int baseIdentity = 0)
                {
                    if (sqlTable == null) return null;
                    @CreateIdentityTreeCacheName = new AutoCSer.Sql.Cache.Whole.Event.IdentityTree<tableType, @Type.FullName, tableType>(sqlTable, null, group, baseIdentity);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreateIdentityTreeCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreateIdentityTreeCacheName;
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreateIdentityTree
                #region IF CacheType=CreatePrimaryKey
                #region IF IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType> @CreatePrimaryKeyMemberCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <typeparam name="memberCacheType"></typeparam>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType> createCache(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, int group = 0)
                {
                    if (sqlTable == null) return null;
                    @CreatePrimaryKeyMemberCacheName = new AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType>(sqlTable, memberCache, group);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreatePrimaryKeyMemberCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreatePrimaryKeyMemberCacheName;
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, tableType, @PrimaryKeyType> @CreatePrimaryKeyCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, tableType, @PrimaryKeyType> createCache(int group = 0)
                {
                    if (sqlTable == null) return null;
                    @CreatePrimaryKeyCacheName = new AutoCSer.Sql.Cache.Whole.Event.PrimaryKey<tableType, @Type.FullName, tableType, @PrimaryKeyType>(sqlTable, null, group);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreatePrimaryKeyCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreatePrimaryKeyCacheName;
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreatePrimaryKey
                #region IF CacheType=CreatePrimaryKeyArray
                #region IF IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType> @CreatePrimaryKeyArrayMemberCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <typeparam name="memberCacheType"></typeparam>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType> createCache/*NOTE*/<T>/*NOTE*/(System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, int group = 0)
                {
                    if (sqlTable == null) return null;
                    @CreatePrimaryKeyArrayMemberCacheName = new AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, memberCacheType, @PrimaryKeyType>(sqlTable, memberCache, group);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreatePrimaryKeyArrayMemberCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreatePrimaryKeyArrayMemberCacheName;
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, tableType, @PrimaryKeyType> @CreatePrimaryKeyArrayCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, tableType, @PrimaryKeyType> createCache/*NOTE*/<T>/*NOTE*/(int group = 0)
                {
                    if (sqlTable == null) return null;
                    @CreatePrimaryKeyArrayCacheName = new AutoCSer.Sql.Cache.Whole.Event.PrimaryKeyArray<tableType, @Type.FullName, tableType, @PrimaryKeyType>(sqlTable, null, group);
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(@CreatePrimaryKeyArrayCacheName/**/.Values);
                    #endregion IF NowTimeMembers.Length
                    return @CreatePrimaryKeyArrayCacheName;
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreatePrimaryKeyArray
                #region IF CacheType=CreateMemberKey
                #region IF IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.Cache<tableType, @Type.FullName, memberCacheType> @CreateMemberKeyMemberCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <typeparam name="targetType"></typeparam>
                /// <typeparam name="targetModelType"></typeparam>
                /// <typeparam name="targetMemberCacheType"></typeparam>
                /// <typeparam name="keyType"></typeparam>
                /// <typeparam name="memberKeyType"></typeparam>
                /// <param name="targetCache">目标缓存</param>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="getKey">键值获取器</param>
                /// <param name="getMemberKey">成员缓存键值获取器</param>
                /// <param name="member">缓存成员</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, memberCacheType, keyType, memberKeyType, targetMemberCacheType> createCache<targetType, targetModelType, targetMemberCacheType, keyType, memberKeyType>(AutoCSer.Sql.Cache.Whole.Event.Key<targetType, targetModelType, targetMemberCacheType, keyType> targetCache, System.Linq.Expressions.Expression<Func<tableType, memberCacheType>> memberCache, Func<@Type.FullName, keyType> getKey, Func<@Type.FullName, memberKeyType> getMemberKey, System.Linq.Expressions.Expression<Func<targetMemberCacheType, System.Collections.Generic.Dictionary<AutoCSer.RandomKey<memberKeyType>, tableType>>> member, int group = 0)
                    where keyType : struct, IEquatable<keyType>
                    where memberKeyType : struct, IEquatable<memberKeyType>
                    where targetType : class, targetModelType
                    where targetModelType : class
                    where targetMemberCacheType : class
                {
                    if (sqlTable == null) return null;
                    AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, memberCacheType, keyType, memberKeyType, targetMemberCacheType> cache = new AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, memberCacheType, keyType, memberKeyType, targetMemberCacheType>(sqlTable, memberCache, getKey, getMemberKey, targetCache.GetMemberCacheByKey, member, targetCache.GetAllMemberCache, group);
                    @CreateMemberKeyMemberCacheName = cache;
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(cache.Values);
                    #endregion IF NowTimeMembers.Length
                    return cache;
                }
                #endregion IF IsMemberCache
                #region NOT IsMemberCache
                /// <summary>
                /// SQL默认缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Whole.Event.Cache<tableType, @Type.FullName, tableType> @CreateMemberKeyCacheName;
                /// <summary>
                /// 创建SQL默认缓存
                /// </summary>
                /// <typeparam name="targetType"></typeparam>
                /// <typeparam name="targetModelType"></typeparam>
                /// <typeparam name="targetMemberCacheType"></typeparam>
                /// <typeparam name="keyType"></typeparam>
                /// <typeparam name="memberKeyType"></typeparam>
                /// <param name="targetCache">目标缓存</param>
                /// <param name="memberCache">成员缓存</param>
                /// <param name="getKey">键值获取器</param>
                /// <param name="getMemberKey">成员缓存键值获取器</param>
                /// <param name="member">缓存成员</param>
                /// <param name="group">数据分组</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, tableType, keyType, memberKeyType, targetMemberCacheType> createCache<targetType, targetModelType, targetMemberCacheType, keyType, memberKeyType>(AutoCSer.Sql.Cache.Whole.Event.Key<targetType, targetModelType, targetMemberCacheType, keyType> targetCache, Func<@Type.FullName, keyType> getKey, Func<@Type.FullName, memberKeyType> getMemberKey, System.Linq.Expressions.Expression<Func<targetMemberCacheType, System.Collections.Generic.Dictionary<AutoCSer.RandomKey<memberKeyType>, tableType>>> member, int group = 0)
                    where keyType : struct, IEquatable<keyType>
                    where memberKeyType : struct, IEquatable<memberKeyType>
                    where targetType : class, targetModelType
                    where targetModelType : class
                    where targetMemberCacheType : class
                {
                    if (sqlTable == null) return null;
                    AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, tableType, keyType, memberKeyType, targetMemberCacheType> cache = new AutoCSer.Sql.Cache.Whole.Event.MemberKey<tableType, @Type.FullName, tableType, keyType, memberKeyType, targetMemberCacheType>(sqlTable, null, getKey, getMemberKey, targetCache.GetMemberCacheByKey, member, targetCache.GetAllMemberCache, group);
                    @CreateMemberKeyCacheName = cache;
                    sqlTable/**/.CacheCreated();
                    #region IF NowTimeMembers.Length
                    NowTimes.Load(cache.Values);
                    #endregion IF NowTimeMembers.Length
                    return cache;
                }
                #endregion NOT IsMemberCache
                #endregion IF CacheType=CreateMemberKey

                #region IF CounterCacheType=IdentityCounter
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                #region IF IsIdentity64
                protected static readonly AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName> @IdentityCounterCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName>(sqlTable, 1);
                #endregion IF IsIdentity64
                #region NOT IsIdentity64
                protected static readonly AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName> @IdentityCounter32CacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName>(sqlTable, 1);
                #endregion NOT IsIdentity64
                #endregion IF CounterCacheType=IdentityCounter
                #region IF CounterCacheType=PrimaryKeyCounter
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                protected static readonly AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType> @PrimaryKeyCounterCacheName = sqlTable == null ? null : new AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType>(sqlTable, 1);
                #endregion IF CounterCacheType=PrimaryKeyCounter

                #region IF CounterCacheType=CreateIdentityCounterMemberQueue
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Counter.Event.MemberIdentity<tableType, @Type.FullName, memberCacheType> @CreateIdentityCounterMemberQueueCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="cache">自增ID整表缓存</param>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns></returns>
                protected static AutoCSer.Sql.Cache.Counter.MemberQueue<tableType, @Type.FullName, memberCacheType, int> createCounterMemberQueue(AutoCSer.Sql.Cache.Whole.Event.IdentityMemberMap<tableType, @Type.FullName, memberCacheType> cache, int group = 1, int maxCount = 0)
                {
                    @CreateIdentityCounterMemberQueueCacheName = cache.CreateCounter(value => value.Counter, group);
                    return @CreateIdentityCounterMemberQueueCacheName/**/.CreateMemberQueue(value => value.NodeValue, value => value.PreviousNode, value => value.NextNode, maxCount);
                }
                #endregion IF CounterCacheType=CreateIdentityCounterMemberQueue
                #region IF CounterCacheType=CreateIdentityCounterQueue
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                #region IF IsIdentity64
                protected static AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName> @CreateIdentityCounterQueueCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, long> createIdentityCounterQueue(int group = 1, int maxCount = 0)
                {
                    return new AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, long>(@CreateIdentityCounterQueueCacheName = new AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName>(sqlTable, group), sqlTable/**/.Get, maxCount);
                }
                #endregion IF IsIdentity64
                #region NOT IsIdentity64
                protected static AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName> @CreateIdentityCounter32QueueCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, int> @CreateIdentityCounterQueueMethodName(int group = 1, int maxCount = 0)
                {
                    return new AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, int>(@CreateIdentityCounter32QueueCacheName = new AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName>(sqlTable, group), sqlTable/**/.Get, maxCount);
                }
                #endregion NOT IsIdentity64
                #endregion IF CounterCacheType=CreateIdentityCounterQueue
                #region IF CounterCacheType=CreateIdentityCounterQueueList
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                #region IF IsIdentity64
                protected static AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName> @CreateIdentityCounterQueueListCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, long, keyType> createIdentityCounterQueueList<keyType>(System.Linq.Expressions.Expression<Func<@Type.FullName, keyType>> getKey, Func<keyType, System.Linq.Expressions.Expression<Func<@Type.FullName, bool>>> getWhere, int group = 0, int maxCount = 0)
                    where keyType : IEquatable<keyType>
                {
                    return new AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, long, keyType>(@CreateIdentityCounterQueueListCacheName = new AutoCSer.Sql.Cache.Counter.Event.Identity64<tableType, @Type.FullName>(sqlTable, group), getKey, getWhere, maxCount);
                }
                #endregion IF IsIdentity64
                #region NOT IsIdentity64
                protected static AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName> @CreateIdentityCounter32QueueListCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, int, keyType> @CreateIdentityCounterQueueListMethodName<keyType>(System.Linq.Expressions.Expression<Func<@Type.FullName, keyType>> getKey, Func<keyType, System.Linq.Expressions.Expression<Func<@Type.FullName, bool>>> getWhere, int group = 0, int maxCount = 0)
                    where keyType : IEquatable<keyType>
                {
                    return new AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, int, keyType>(@CreateIdentityCounter32QueueCacheName = new AutoCSer.Sql.Cache.Counter.Event.Identity<tableType, @Type.FullName>(sqlTable, group), getKey, getWhere, maxCount);
                }
                #endregion NOT IsIdentity64
                #endregion IF CounterCacheType=CreateIdentityCounterQueueList
                #region IF CounterCacheType=CreatePrimaryKeyCounterQueue
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType> @CreatePrimaryKeyCounterQueueCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, @PrimaryKeyType> createPrimaryKeyCounterQueue(int group = 1, int maxCount = 0)
                {
                    return new AutoCSer.Sql.Cache.Counter.Queue<tableType, @Type.FullName, @PrimaryKeyType>(@CreatePrimaryKeyCounterQueueCacheName = new AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType>(sqlTable, group), sqlTable/**/.GetByPrimaryKey, maxCount);
                }
                #endregion IF CounterCacheType=CreatePrimaryKeyCounterQueue
                #region IF CounterCacheType=CreatePrimaryKeyCounterQueueList
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType> @CreatePrimaryKeyCounterQueueListCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="getKey">缓存关键字获取器</param>
                /// <param name="getWhere">条件表达式获取器</param>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, @PrimaryKeyType, keyType> createPrimaryKeyCounterQueueList<keyType>(System.Linq.Expressions.Expression<Func<@Type.FullName, keyType>> getKey, Func<keyType, System.Linq.Expressions.Expression<Func<@Type.FullName, bool>>> getWhere, int group = 1, int maxCount = 0)
                    where keyType : IEquatable<keyType>
                {
                    return new AutoCSer.Sql.Cache.Counter.QueueList<tableType, @Type.FullName, @PrimaryKeyType, keyType>(@CreatePrimaryKeyCounterQueueListCacheName = new AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType>(sqlTable, group), getKey, getWhere, maxCount);
                }
                #endregion IF CounterCacheType=CreatePrimaryKeyCounterQueueList
                #region IF CounterCacheType=CreatePrimaryKeyCounterQueueDictionary
                /// <summary>
                /// SQL默认计数缓存
                /// </summary>
                protected static AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType> @CreatePrimaryKeyCounterQueueDictionaryCacheName;
                /// <summary>
                /// 创建SQL默认先进先出优先队列缓存
                /// </summary>
                /// <param name="getKey">缓存关键字获取器</param>
                /// <param name="getWhere">条件表达式获取器</param>
                /// <param name="getDictionaryKey">缓存字典关键字获取器</param>
                /// <param name="group">数据分组</param>
                /// <param name="maxCount">缓存默认最大容器大小</param>
                /// <returns>数据分组</returns>
                protected static AutoCSer.Sql.Cache.Counter.QueueDictionary<tableType, @Type.FullName, @PrimaryKeyType, keyType, dictionaryKeyType> createPrimaryKeyCounterQueueDictionary<keyType, dictionaryKeyType>(System.Linq.Expressions.Expression<Func<@Type.FullName, keyType>> getKey, Func<keyType, System.Linq.Expressions.Expression<Func<@Type.FullName, bool>>> getWhere, Func<tableType, dictionaryKeyType> getDictionaryKey, int group = 1, int maxCount = 0)
                    where keyType : IEquatable<keyType>
                    where dictionaryKeyType : IEquatable<dictionaryKeyType>
                {
                    return new AutoCSer.Sql.Cache.Counter.QueueDictionary<tableType, @Type.FullName, @PrimaryKeyType, keyType, dictionaryKeyType>(@CreatePrimaryKeyCounterQueueDictionaryCacheName = new AutoCSer.Sql.Cache.Counter.Event.PrimaryKey<tableType, @Type.FullName, @PrimaryKeyType>(sqlTable, group), getKey, getWhere, getDictionaryKey, maxCount);
                }
                #endregion IF CounterCacheType=CreatePrimaryKeyCounterQueueDictionary

                #region IF IndexMembers.Length
                /// <summary>
                /// 成员索引定义
                /// </summary>
                protected static class MemberIndexs
                {
                    #region LOOP IndexMembers
                    #region PUSH Member
                    #region IF XmlDocument
                    /// <summary>
                    /// @XmlDocument (成员索引)
                    /// </summary>
                    #endregion IF XmlDocument
                    public static readonly AutoCSer.Metadata.MemberMap<@Type.FullName>.MemberIndex @MemberName = AutoCSer.Metadata.MemberMap<@Type.FullName>.MemberIndex.Create(value => value.@MemberName);
                    #endregion PUSH Member
                    #endregion LOOP IndexMembers
                }
                #endregion IF IndexMembers.Length
                #region IF Attribute.LogServerName
                [AutoCSer.Metadata.Ignore]
                tableType AutoCSer.Sql.LogStream.IMemberMapValueLink<tableType>.MemberMapValueLink { get; set; }
                private readonly static AutoCSer.Sql.LogStream.Log<tableType, @Type.FullName> sqlStream = sqlTable == null ? null : new AutoCSer.Sql.LogStream.Log<tableType, @Type.FullName>(sqlTable/*LOOP:LogMembers*//*IF:IsSqlStreamCount*//*PUSH:Member*/, @MemberIndex/*PUSH:Member*//*IF:IsSqlStreamCount*//*LOOP:LogMembers*/);
                /// <summary>
                /// 日志处理
                /// </summary>
                /// <param name="onLog"></param>
                [AutoCSer.Net.TcpStaticServer.KeepCallbackMethod(/*NOT:Attribute.IsLogSerializeReferenceMember*/ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, /*NOT:Attribute.IsLogSerializeReferenceMember*/ServerName = "@Attribute.LogServerName")]
                [System.Runtime.CompilerServices.MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
                protected static void onSqlLog(Func<AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Sql.LogStream.Log<tableType, @Type.FullName>.Data>, bool> onLog)
                {
                    sqlStream/**/.Add(onLog);
                }
                #region IF Attribute.IsLogClientGetCache
                #region IF Identity
                #region PUSH Identity
                /// <summary>
                /// 获取数据
                /// </summary>
                /// <param name="@MemberName">@XmlDocument</param>
                /// <returns></returns>
                [AutoCSer.Net.TcpStaticServer.Method(/*NOT:Attribute.IsLogSerializeReferenceMember*/ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, /*NOT:Attribute.IsLogSerializeReferenceMember*/ServerTask = AutoCSer.Net.TcpServer.ServerTaskType.Synchronous, ServerName = "@Attribute.LogServerName")]
                protected static tableType getSqlCache(int @MemberName)
                {
                    return @IdentityArrayCacheName[@MemberName];
                }
                #endregion PUSH Identity
                #endregion IF Identity
                #region NOT Identity
                #region NOT CacheType=CreateMemberKey
                /// <summary>
                /// 获取数据
                /// </summary>
                /// <param name="key">关键字</param>
                /// <returns></returns>
                [AutoCSer.Net.TcpStaticServer.Method(/*NOT:Attribute.IsLogSerializeReferenceMember*/ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, /*NOT:Attribute.IsLogSerializeReferenceMember*/ServerTask = AutoCSer.Net.TcpServer.ServerTaskType.Synchronous, ServerName = "@Attribute.LogServerName")]
                protected static tableType getSqlCache(@PrimaryKeyType key)
                {
                    return @PrimaryKeyCacheName[key];
                }
                #endregion NOT CacheType=CreateMemberKey
                #endregion NOT Identity
                #endregion IF Attribute.IsLogClientGetCache
                #region IF LogMembers.Length
                /// <summary>
                /// 计算字段日志流
                /// </summary>
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                public struct SqlLogMembers
                {
                    /// <summary>
                    /// 数据对象
                    /// </summary>
                    internal SqlModel<tableType/*IF:IsMemberCache*/, memberCacheType/*IF:IsMemberCache*/> _value_;
                    #region LOOP LogMembers
                    #region PUSH Member
                    private static readonly AutoCSer.Metadata.MemberMap<@Type.FullName> @MemberMapName = sqlStream/**/.CreateMemberMap(value => value.@MemberName);
                    #region IF XmlDocument
                    /// <summary>
                    /// @XmlDocument (更新日志流)
                    /// </summary>
                    /// <param name="value"></param>
                    #endregion IF XmlDocument
                    [System.Runtime.CompilerServices.MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
                    public void @MemberName(@MemberType.FullName value)
                    {
                        #region IF MemberType.IsIEquatable
                        if (!value.Equals(_value_.@MemberName))
                        #endregion IF MemberType.IsIEquatable
                        {
                            _value_.@MemberName = value;
                            @MemberName();
                        }
                    }
                    #region IF XmlDocument
                    /// <summary>
                    /// @XmlDocument (更新日志流)
                    /// </summary>
                    #endregion IF XmlDocument
                    [System.Runtime.CompilerServices.MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
                    public void @MemberName()
                    {
                        sqlStream/**/.Update((tableType)_value_, @MemberMapName);
                    }
                    #region IF IsSqlStreamCount
                    #region NOT SqlStreamCountType
                    /// <summary>
                    /// @XmlDocument 计算初始化完毕
                    /// </summary>
                    public static void @MemberLoadedMethodName() { sqlStream/**/.LoadMember(@MemberIndex); }
                    #endregion NOT SqlStreamCountType
                    #endregion IF IsSqlStreamCount
                    #endregion PUSH Member
                    #endregion LOOP LogMembers
                    #region IF SqlStreamTypeCount
                    /// <summary>
                    /// 根据日志流计数完成类型初始化完毕
                    /// </summary>
                    /// <param name="type"></param>
                    internal static void _LoadCount_(AutoCSer.Sql.LogStream.LoadedType type)
                    {
                        #region LOOP LogMembers
                        #region PUSH Member
                        #region IF SqlStreamCountType
                        if (type.Equals(typeof(@SqlStreamCountType.FullName), @CountTypeNumber)) sqlStream/**/.LoadMember(@MemberIndex);
                        #endregion IF SqlStreamCountType
                        #endregion PUSH Member
                        #endregion LOOP LogMembers
                    }
                    #endregion IF SqlStreamTypeCount
                }
                /// <summary>
                /// 计算字段日志流
                /// </summary>
                [AutoCSer.Metadata.Ignore]
                public SqlLogMembers @LogMemberName
                {
                    get { return new SqlLogMembers { _value_ = this }; }
                }
                #endregion IF LogMembers.Length
                #endregion IF Attribute.LogServerName
                #region IF NowTimeMembers.Length
                /// <summary>
                /// 当前时间定义
                /// </summary>
                protected static class NowTimes
                {
                    #region LOOP NowTimeMembers
                    #region IF XmlDocument
                    /// <summary>
                    /// @XmlDocument 当前时间
                    /// </summary>
                    #endregion IF XmlDocument
                    public static readonly AutoCSer.Sql.NowTime @MemberName = sqlTable == null ? null : new AutoCSer.Sql.NowTime(sqlTable.NowTimeMilliseconds);
                    #endregion LOOP NowTimeMembers
                    /// <summary>
                    /// 初始化当前时间
                    /// </summary>
                    /// <param name="values">缓存数据</param>
                    public static void Load(System.Collections.Generic.IEnumerable<tableType> values)
                    {
                        foreach (tableType value in values)
                        {
                            #region LOOP NowTimeMembers
                            @MemberName/**/.SetMaxTime(/*NOTE*/(DateTime)(object)/*NOTE*//*PUSH:Member*/value.@MemberName/*PUSH:Member*/);
                            #endregion LOOP NowTimeMembers
                        }
                        #region LOOP NowTimeMembers
                        @MemberName/**/.SetMaxTime();
                        #endregion LOOP NowTimeMembers
                    }
                }
                #region IF IsLoadNowTimeCache
                static SqlModel()
                {
                    if (@IdentityArrayCacheName != null) NowTimes.Load(@IdentityArrayCacheName/**/.Values);
                }
                #endregion IF IsLoadNowTimeCache
                #endregion IF NowTimeMembers.Length
                #region IF CounterMembers.Length
                /// <summary>
                /// 计数成员
                /// </summary>
                protected static class SqlCounter
                {
                    #region LOOP CounterMembers
                    #region PUSH Member
                    #region IF XmlDocument
                    /// <summary>
                    /// @XmlDocument 当前时间
                    /// </summary>
                    #endregion IF XmlDocument
                    public static AutoCSer.Sql.Cache.Whole.CountMember @MemberName = AutoCSer.Sql.Cache.Whole.CountMember.Null;
                    #endregion PUSH Member
                    #endregion LOOP CounterMembers
                }
                #region LOOP CounterMembers
                #region PUSH Member
                #region IF Attribute.ReadServerName
                /// <summary>
                /// 获取 @XmlDocument
                /// </summary>
                #region PUSH Identity
                /// <param name="@MemberName">@XmlDocument</param>
                #endregion PUSH Identity
                /// <returns>@XmlDocument</returns>
                [AutoCSer.Net.TcpStaticServer.Method(ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, ServerTask = AutoCSer.Net.TcpServer.ServerTaskType.Synchronous, ServerName = "@Attribute.ReadServerName")]
                [System.Runtime.CompilerServices.MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
                protected static int @GetMethodName(/*PUSH:Identity*/@MemberType.FullName @MemberName/*PUSH:Identity*/)
                {
                    return SqlCounter.@MemberName/**/.Get(/*NOTE*/(int)(object)/*NOTE*//*PUSH:Identity*/@MemberName/*PUSH:Identity*/);
                }
                #region IF XmlDocument
                /// <summary>
                /// @XmlDocument 总计数
                /// </summary>
                #endregion IF XmlDocument
                [AutoCSer.Net.TcpStaticServer.Method(ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, ServerTask = AutoCSer.Net.TcpServer.ServerTaskType.Synchronous, ServerName = "@Attribute.ReadServerName")]
                protected static long @TotalMemberName
                {
                    get { return SqlCounter.@MemberName/**/.TotalCount; }
                }
                #endregion IF Attribute.ReadServerName
                #region IF Attribute.WriteServerName
                /// <summary>
                /// @XmlDocument 增加计数
                /// </summary>
                #region PUSH Identity
                /// <param name="@MemberName">@XmlDocument</param>
                #endregion PUSH Identity
                [AutoCSer.Net.TcpStaticServer.Method(ParameterFlags = AutoCSer.Net.TcpServer.ParameterFlags.OutputSerializeBox, ClientTask = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsClientAsynchronous = true, IsClientSynchronous = false, ServerName = "@Attribute.WriteServerName")]
                [System.Runtime.CompilerServices.MethodImpl(AutoCSer.MethodImpl.AggressiveInlining)]
                protected static void @IncMethodName(/*PUSH:Identity*/@MemberType.FullName @MemberName/*PUSH:Identity*/)
                {
                    SqlCounter.@MemberName/**/.Inc(/*NOTE*/(int)(object)/*NOTE*//*PUSH:Identity*/@MemberName/*PUSH:Identity*/);
                }
                #endregion IF Attribute.WriteServerName
                #endregion PUSH Member
                #endregion LOOP CounterMembers
                /// <summary>
                /// 初始化计数成员
                /// </summary>
                /// <param name="cache"></param>
                protected static void createCounter(AutoCSer.Sql.Cache.Whole.Event.IdentityCache<tableType, @Type.FullName, memberCacheType> cache)
                {
                    #region LOOP CounterMembers
                    #region PUSH Member
                    SqlCounter.@MemberName = new AutoCSer.Sql.Cache.Whole.CountMember<tableType, @Type.FullName, memberCacheType>(cache, value => /*NOTE*/(int)(object)/*NOTE*/value.@MemberName, /*PUSH:Attribute*/@Timeout/*PUSH:Attribute*/);
                    #endregion PUSH Member
                    #endregion LOOP CounterMembers
                }
                #endregion IF CounterMembers.Length
                #region LOOP WebPaths
                #region IF MemberType.XmlDocument
                /// <summary>
                /// @MemberType.XmlDocument
                /// </summary>
                #endregion IF MemberType.XmlDocument
                [AutoCSer.Metadata.Ignore]
                public @MemberType.FullName @PathMemberName
                {
                    get { return new @MemberType.FullName { /*LOOP:Members*/@MemberName = @MemberName/*IF:MemberIndex*/, /*IF:MemberIndex*//*LOOP:Members*//*NOTE*/ PropertyName = null/*NOTE*/ }; }
                }
                #endregion LOOP WebPaths
            }
        }
        #endregion PART CLASS
    }
    #region NOTE
    /// <summary>
    /// CSharp模板公用模糊类型
    /// </summary>
    internal partial class Pub
    {
        /// <summary>
        /// 关键字类型
        /// </summary>
        public struct PrimaryKeyType : IEquatable<PrimaryKeyType>
        {
            /// <summary>
            /// 关键字比较
            /// </summary>
            /// <param name="other">关键字</param>
            /// <returns>是否相等</returns>
            public bool Equals(PrimaryKeyType other) { return false; }
        }
        /// <summary>
        /// 日志流计数完成类型
        /// </summary>
        public class SqlStreamCountType : Pub
        {
        }
    }
    #endregion NOTE
}
