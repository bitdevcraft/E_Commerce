import { Button, Descriptions, DescriptionsProps } from "antd";
import { useStore } from "../../../app/store/store";
import { CompanyInfo } from "../../../app/models/company";

function CompanyProfileView() {
  const { appCompanyStore } = useStore();

  const company = new CompanyInfo(appCompanyStore.company ?? undefined);
  const items: DescriptionsProps["items"] = Object.keys(company)
    .filter((key) => key !== "id")
    .map((key, index) => ({
      key: index.toString(),
      label: key.charAt(0).toUpperCase() + key.slice(1),
      children:
        key === "logo" ? (
          <img
            src={`${import.meta.env.VITE_DEFAULT_URL}${
              company[key as keyof CompanyInfo]
            }`}
            alt=""
            className="w-32"
          />
        ) : (
          <p>{company[key as keyof CompanyInfo]}</p>
        ),
      span: key === "name" ? 2 : key === "address" ? 3 : 1,
    }));

  return (
    <Descriptions
      title="Company Info"
      items={items}
      layout="vertical"
      bordered
      labelStyle={{
        fontWeight: "700",
        fontSize: "14px",
      }}
      className="pb-32 px-4"
      extra={
        <Button
          type="primary"
          className="bg-blue-400"
          href="/admin/companyprofile-edit"
        >
          Edit
        </Button>
      }
    />
  );
}

export default CompanyProfileView;
