import { useEffect, useState } from "react";
import { AppCompany, CompanyInfo } from "../../../app/models/company";
import { useStore } from "../../../app/store/store";
import { Form, Formik } from "formik";
import { Button } from "antd";
import { MyTextAreaInput, MyTextInput } from "../../../app/common/form";

function CompanyProfileEdit() {
  const { appCompanyStore } = useStore();
  const { company } = appCompanyStore;

  const [companyDetail, setCompanyDetail] = useState<CompanyInfo>(
    new CompanyInfo()
  );

  useEffect(() => {
    if (company) {
      setCompanyDetail(new CompanyInfo(company));
      console.log(new CompanyInfo(company));
    }
  }, [company]);

  const onFormSubmit = (values: AppCompany) => {
    appCompanyStore.updateCompanyDetail(values);
  };

  return (
    <Formik
      enableReinitialize
      initialValues={companyDetail}
      onSubmit={onFormSubmit}
    >
      {({ handleSubmit, isSubmitting }) => (
        <Form onSubmit={handleSubmit} className="p-4 space-y-3 pb-32">
          <p className="font-bold">Company Profile Edit</p>
          <div>
            <p>Name</p>
            <MyTextInput name="name" placeholder="Name" />
          </div>
          <div>
            <p>Email</p>
            <MyTextInput name="email" placeholder="Email" />
          </div>
          <div>
            <p>Mobile No</p>
            <MyTextInput name="mobileNo" placeholder="Mobile No" />
          </div>
          <div>
            <p>Hotline</p>
            <MyTextInput name="hotline" placeholder="Hotline" />
          </div>
          <div>
            <p>About</p>
            <MyTextAreaInput name="about" placeholder="About" />
          </div>
          <div>
            <p>Vision</p>
            <MyTextAreaInput name="vision" placeholder="Vision" />
          </div>
          <div>
            <p>Mission</p>
            <MyTextAreaInput name="mission" placeholder="Mission" />
          </div>
          <div>
            <p>Address</p>
            <MyTextInput name="address" placeholder="Address" />
          </div>
          <Button
            type="primary"
            className="w-full border bg-blue-400"
            htmlType="submit"
            loading={isSubmitting}
          >
            Submit
          </Button>
        </Form>
      )}
    </Formik>
  );
}

export default CompanyProfileEdit;
