export interface AppCompany {
  id?: string;
  logo: string;
  name: string;
  email: string;
  mobileNo: string;
  hotline: string;
  about: string;
  vision: string;
  mission: string;
  address: string;
}

export class CompanyInfo {
  id?: string = "";
  logo: string = "";
  name: string = "";
  email: string = "";
  mobileNo: string = "";
  hotline: string = "";
  about: string = "";
  vision: string = "";
  mission: string = "";
  address: string = "";

  constructor(company?: CompanyInfo) {
    if (company) {
      this.id = company.id;
      this.logo = company.logo;
      this.name = company.name;
      this.email = company.email;
      this.mobileNo = company.mobileNo;
      this.hotline = company.hotline;
      this.about = company.about;
      this.vision = company.vision;
      this.mission = company.mission;
      this.address = company.address;
    }
  }
}

export class AppCompany implements AppCompany {
  constructor(init?: CompanyInfo) {
    Object.assign(this, init);
  }
}
