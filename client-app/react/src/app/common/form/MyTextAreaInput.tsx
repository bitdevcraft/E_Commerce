import { Input } from "antd";
import { useField } from "formik";
import { FaInfoCircle } from "react-icons/fa";

const { TextArea } = Input;
interface Props {
  placeholder: string;
  name: string;
}

export default function MyTextAreaInput(props: Readonly<Props>) {
  const [field, meta] = useField(props.name);
  return (
    <div className="w-full">
      <TextArea rows={5} allowClear {...field} {...props} />
      {meta.touched && meta.error ? (
        <p className="flex items-center gap-1 font-normal text-red-500 text-xs">
          <FaInfoCircle size={10} />
          {meta.error}
        </p>
      ) : null}
    </div>
  );
}
