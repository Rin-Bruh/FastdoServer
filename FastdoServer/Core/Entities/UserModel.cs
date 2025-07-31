using FastdoServer.Infrastructure.Helpers;
using MongoDB.Bson.Serialization.Attributes;


namespace FastdoServer.Core.Entities
{
	[BsonIgnoreExtraElements]
	public class UserModel : BaseEntity, IDisposable
	{
		/// <summary>Mã nhân viên</summary>
		public string code { get; set; }

		public string google_account { get; set; }

		public bool delete { get; set; }

		public bool active { get; set; }

		public string email { get; set; }

		public string phone { get; set; }

		public string social { get; set; }

		public string note { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }

		public string FullName
		{
			get { return $"{last_name} {first_name}"; }
		}

		public string avatar { get; set; }

		public string password { get; set; }

		public string session { get; set; }

		public long online { get; set; }

		public long last_login { get; set; }

		public long create_date { get; set; }

		/// <summary>Admin hệ thống</summary>
		public bool is_admin { get; set; }

		/// <summary>Chủ tổ chức</summary>
		public bool is_customer { get; set; }

		/// <summary>Không thống kê</summary>
		public bool no_report { get; set; }

		/// <summary>Tự checkin OKRs</summary>
		public bool okr_checkin { get; set; }

		/// <summary>Nhận thông báo đổi quà</summary>
		public bool noti_store { get; set; } = true;

		/// <summary>Quyền trong công ty: 1. Admin, 2. QLHT, 3. Nhân viên</summary>
		public int role { get; set; }

		/// <summary>Chức danh: 1. quản lý, 2. phó quản lý, 3. nhân viên</summary>
		public int title { get; set; }
		/// <summary>Tên chức danh</summary>
		public string title_name { get; set; }

		/// <summary>Tên nghề nghiệp</summary>
		public string job_title { get; set; }

		/// <summary>Danh sách công ty trực thuộc, tương lai sẽ bỏ</summary>
		public List<Company> companys { get; set; } = new();

		/// <summary>Quyền theo chức năng</summary>
		public RoleManage role_manage { get; set; } = new();

		/// <summary>Danh sách ID phòng ban trực thuộc</summary>
		public List<string> departments_id { get; set; } = new();

		/// <summary>Danh sách ID phòng ban ghim trong đội nhóm</summary>
		public List<string> teams_id { get; set; } = new();

		/// <summary>Danh sách tên phòng ban trực thuộc</summary>
		public string departments_name { get; set; }

		/// <summary>Phòng ban mặc định cho các bộ lọc</summary>
		public string department_default { get; set; }

		/// <summary>Trực thuộc công ty</summary>
		public string company_id { get; set; }

		/// <summary>Trực thuộc phòng ban</summary>
		public string department_id { get; set; }

		/// <summary>Tổng số sao đang có</summary>
		public int star_total { get; set; }

		/// <summary>Tổng số sao được cấp</summary>
		public int star_distribute { get; set; }

		/// <summary>Tổng số sao nhận được </summary>
		public int star_receive { get; set; }

		/// <summary>Tổng sao cho đi</summary>
		public int star_give { get; set; }

		/// <summary>Trang mặc định khi vào phần mềm</summary>
		public string page_default { get; set; }

		///// <summary>Không thống kê: OKRs</summary>
		//public bool no_report_okr { get; set; }

		/// <summary>Không thống kê: CFRs</summary>
		public bool no_report_cfr { get; set; }

		/// <summary>Không thống kê: Todolist</summary>
		public bool no_report_todolist { get; set; }

		///// <summary>Không thống kê: Kaizen</summary>
		//public bool no_report_kaizen { get; set; }

		/// <summary>Không thống kê: Thành tựu</summary>
		public bool no_report_achievement { get; set; }

		/// <summary>Sản phẩm được sử dụng</summary>
		public List<string> products { get; set; } = new();

		/// <summary>Sản phẩm ưu thích</summary>
		public List<string> products_favorite { get; set; } = new();

		/// <summary>Số dư tài khoản</summary>
		public int balance { get; set; }

		/// <summary>Mã xác minh</summary>
		public string verify { get; set; }

		/// <summary>Các kế hoạch đã ghim</summary>
		public List<string> plans_pin { get; set; } = new();

		/// <summary>Các kế hoạch đã lưu trữ</summary>
		public List<string> plans_hide { get; set; } = new();

		/// <summary>Chế độ làm việc linh động</summary>
		public bool is_hybrid { get; set; }

		/// <summary>Cookie thiết bị/summary>
		public string device_id { get; set; }

		/// <summary>Tên thiết bị/summary>
		public string device_name { get; set; }

		//public List<string> sidebar_star { get; set; } = new();


		/// <summary>
		/// Thiết bị chấm công mobile
		/// </summary> <summary>
		public List<HrmDeviceModel> devices_timekeeping { get; set; } = new();


		public Custom custom { get; set; } = new();

		/// <summary>Product yêu thích mobile</summary>
		public List<string> products_favorite_app { get; set; } = new();

		/// <summary>
		/// Token định danh người dùng nhận thông báo mobile
		/// </summary>
		public string device_token { get; set; }

		/// <summary>Modules mặc định khi vào phần mềm mobile</summary>
		public string default_module_app { get; set; }


		/// <summary>
		/// 1. Tự đăng ký, 2. Fastdo đăng ký
		/// </summary>
		public int signup_type { get; set; } = 2;

		/// <summary>Công ty trực thuộc</summary>
		public class Company
		{
			public string id { get; set; }
			public string name { get; set; }
		}

		[BsonIgnoreExtraElements]
		/// <summary>Quyền hạn chức năng</summary>
		public class RoleManage
		{
			/// <summary>Cơ cấu</summary>
			public bool system { get; set; }

			/// <summary>OKRs - CFRs</summary>
			public bool okrs { get; set; }

			/// <summary>Kaizen</summary>
			public bool kaizen { get; set; }

			/// <summary>Đào tạo</summary>
			public bool educate { get; set; }

			/// <summary>Đổi quà</summary>
			public bool store { get; set; }

			/// <summary>Tiện ích</summary>
			public bool other { get; set; }

			/// <summary>Hồ sơ nhân sự</summary>
			public bool hrrecords { get; set; }

			/// <summary>Chấm công</summary>
			public bool timekeeping { get; set; }

			/// <summary>Lưu trữ</summary>
			public bool storage { get; set; }

			/// <summary>Ghi nhận</summary>
			public bool cfr { get; set; }

			/// <summary>kpis</summary>
			public bool kpis { get; set; }

			/// <summary>todolist</summary>
			public bool todolist { get; set; }

			/// <summary>profile</summary>
			public bool profile { get; set; }

			/// <summary>meeting</summary>
			public bool meeting { get; set; }

			/// <summary>workflow</summary>
			public bool workflow { get; set; }

			public bool CheckAccessAll()
			{
				return !system && !okrs && !kaizen && !educate && !other && !store && !timekeeping && !storage && !cfr && !kpis && !todolist && !profile && !meeting && !workflow;
			}
		}

		[BsonIgnoreExtraElements]
		public class HrmDeviceModel
		{

			/// <summary>0: điện thoại, 1: máy tính</summary>
			public int type { get; set; }

			/// <summary>Model thiết bị</summary>
			public string device_model { get; set; }

			/// <summary>Version OS</summary>
			public string os_version { get; set; }

			/// <summary>Tên thiết bị</summary>
			public string device_name { get; set; }

			/// <summary>Mã thiết bị</summary>
			public string device_token { get; set; }


			/// <summary> Id thiết bị </summary> 
			[BsonIgnore]
			public string device_id
			{
				get
				{
					return device_model + os_version;
				}
				set { }
			}
		}

		public void Dispose()
		{
			SystemHelper.CleanUp(this.departments_id);
			SystemHelper.CleanUp(this.teams_id);
			SystemHelper.CleanUp(this.products);
			SystemHelper.CleanUp(this.products_favorite);
			SystemHelper.CleanUp(this.plans_hide);
			SystemHelper.CleanUp(this.plans_pin);
			SystemHelper.CleanUp(this.products_favorite_app);

			GC.SuppressFinalize(this);
		}
	}

	[BsonIgnoreExtraElements]
	/// <summary>Thông tin tài khoản</summary>
	public class MemberModel : BaseEntity, IDisposable
	{
		public bool active { get; set; }

		public bool delete { get; set; }

		public string code { get; set; }

		public string name { get; set; }

		public string email { get; set; }

		public string avatar { get; set; }

		/// <summary>Chức danh: 1. quản lý, 2. phó quản lý, 3. nhân viên</summary>
		public int title { get; set; }

		public string job_title { get; set; }

		/// <summary>Danh sách ID phòng ban trực thuộc</summary>
		public List<string> departments_id { get; set; }

		/// <summary>Danh sách tên phòng ban trực thuộc</summary>
		public string departments_name { get; set; }

		/// <summary>Phòng ban mặc định cho các bộ lọc</summary>
		public string department_default { get; set; }

		/// <summary>Quyền trong công ty: 1. Admin, 2. QLHT, 3. Nhân viên</summary>
		public int role { get; set; }

		/// <summary>Quyền theo chức năng</summary>
		public UserModel.RoleManage role_manage { get; set; }

		// <summary>Xử lý cho thống kê chấm công</summary>
		public int count { get; set; }

		// <summary>Xử lý cho workspace</summary>
		public bool is_active { get; set; }

		public void Dispose()
		{
			SystemHelper.CleanUp(this.departments_id);

			GC.SuppressFinalize(this);
		}
	}

	[BsonIgnoreExtraElements]
	public class Custom : IDisposable
	{
		public string okrs_cycle { get; set; }

		public string kpis_cycle { get; set; }

		/// <summary>Lưu Id người được coi todolist cuối cùng</summary>
		public string late_todo_userId { get; set; }

		/// <summary>Hiển thị tất cả OKRs liên kết</summary>
		public bool team_show_all_okrs { get; set; } = true;

		/// <summary>Chế độ hiển thị công việc chờ xác nhận</summary>
		public bool assigned_view { get; set; } = true;

		/// <summary>Chế độ hiển thị sidebar mặc định</summary>
		public bool sidebar_pin { get; set; }

		/// <summary>Chế độ xem trong todolist</summary>
		public int current_view { get; set; }

		/// <summary>Chế độ hiển thị sidebar trong fwork</summary>
		public bool sidebar_fwork { get; set; } = true;

		/// <summary>Chế độ hiển thị sidebar trong fMeeting</summary>
		public bool sidebar_fmeeting { get; set; } = true;

		/// <summary>Chế độ hiển thị sidebar trong workflow</summary>
		public bool sidebar_workflow { get; set; } = true;

		/// <summary>Chế độ xem dánh sách nhiệm vị fMission</summary>
		public bool sidebar_mission { get; set; } = true;

		/// <summary>Chế độ xem slider giới thiệu fMission</summary>
		public bool slider_mission { get; set; } = true;

		/// <summary>Chế độ xem sidebar dữ liệu</summary>
		public bool sidebar_data { get; set; } = true;

		// Xem thông báo khi hoàn thành nhiệm vụ hay chưa → Chưa thì hiện popup
		public bool reward_mission { get; set; } = true;

		public bool isShowAddfwork { get; set; }

		public bool sheets_less { get; set; } = true;

		public List<NotiType> notifications { get; set; } = new();

		public bool email_notification { get; set; } = true;

		public List<string> mail_categories { get; set; } = new();

		public bool mail_nav_collapse { get; set; }

		//public Beta beta_user { get; set; } = new();

		public void Dispose()
		{
			SystemHelper.CleanUp(this.notifications);
			SystemHelper.CleanUp(this.mail_categories);

			GC.SuppressFinalize(this);
		}
	}

	[BsonIgnoreExtraElements]
	public class UserSmall
	{
		public string id { set; get; }
		public string name { set; get; }
		public string avatar { set; get; }
		public int role { set; get; }
	}

	[BsonIgnoreExtraElements]
	public class UserAuthenticationModel
	{
		[BsonId]
		public string id { get; set; }

		public string userId { get; set; }

		public List<Device> devices { get; set; } = new();

		public long update { get; set; }

		public string code { get; set; }

		public bool hide { get; set; }

		public long hide_time { get; set; }

		public class Device
		{
			public string user_agent { get; set; }

			public bool isMobile { get; set; }

			public long count { get; set; }

			public long last_access { get; set; }

			public List<IP> ips { get; set; } = new();
		}

		public class IP
		{
			public string ip { get; set; }

			public long count { get; set; }

			public long last_access { get; set; }
		}

		[BsonIgnore]
		public int point { get; set; }
	}


	[BsonIgnoreExtraElements]
	public class NotiType
	{
		public string name { get; set; }

		public int type_from { get; set; }

		public int type_to { get; set; }

		public bool is_default { get; set; }

		public bool is_prioritize { get; set; }

		public bool is_unchecked { get; set; } = true;
	}

	// list.Add(new ()
	// {
	//    name = "Nhân viên đi trễ/về sớm"",
	//    type_from = 823,
	//    type_to = 823,
	//    is_unchecked = true,
	//    is_default = false,
	//    is_prioritize = false,
	// });

	// list.Add(new()
	// {
	//   name = "Nhân viên không chấm công (Thông báo sau thời gian checkin 30 phút)",
	//   type_from = 824,
	//   type_to = 824,
	// });


	public class UserRoleDepartment
	{
		public string DepartmentId { get; set; }
		public int Role { get; set; }
	}
}
