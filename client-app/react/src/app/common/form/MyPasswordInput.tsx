import { Input } from "antd";
import { useField } from "formik";
import { FaInfoCircle } from "react-icons/fa";

interface Props {
  placeholder: string;
  name: string;
  label?: string;
  type?: string;
  prefix?: React.ReactNode;
  suffix?: React.ReactNode;
}

export default function MyPasswordInput(props: Readonly<Props>) {
  const [field, meta] = useField(props.name);
  return (
    <div>
      <Input.Password
        size="large"
        allowClear
        {...field}
        {...props}
      ></Input.Password>
      {meta.touched && meta.error ? (
        <p className="flex items-center gap-1 font-normal text-red-500 text-xs">
          <FaInfoCircle size={10} />
          {meta.error}
        </p>
      ) : null}
    </div>
  );
}
