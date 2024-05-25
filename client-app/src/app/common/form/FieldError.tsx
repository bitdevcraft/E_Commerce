import { useField } from "formik";

interface Props {
  name: string;
}

function FieldError(props: Readonly<Props>) {
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [, meta] = useField(props.name);
  return (
    <>
      {meta.touched && meta.error ? (
        <p className="mt-2 flex items-center gap-1 font-normal text-red-700">
          {meta.error}
        </p>
      ) : null}
    </>
  );
}

export default FieldError;
