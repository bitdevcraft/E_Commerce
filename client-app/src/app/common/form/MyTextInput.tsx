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

export default function MyTextInput(props: Readonly<Props>) {
  const [field, meta] = useField(props.name);
  return (
    <div className="w-full">
      <Input size="large" allowClear {...field} {...props} />
      {meta.touched && meta.error ? (
        <p className="flex items-center gap-1 font-normal text-red-500 text-xs">
          <FaInfoCircle size={10} />
          {meta.error}
        </p>
      ) : null}
    </div>
  );
}
