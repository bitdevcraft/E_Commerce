import { Button, Flex } from "antd";
import { Form, Formik } from "formik";
import { AiOutlineKey, AiOutlineUser } from "react-icons/ai";
import * as yup from "yup";
import { MyPasswordInput, MyTextInput } from "../../app/common/form";
import { useStore } from "../../app/store/store";
import { UserFormValues } from "../../app/models/user";

const schema = yup
  .object({
    email: yup
      .string()
      .required()
      .matches(/^[\w-\\.]+@([\w-]+\.)+[\w-]{2,4}$/, "Invalid Email"),
    password: yup.string().required("Password is Required"),
  })
  .required();

function LoginForm() {
  const { userStore } = useStore();

  const onLogin = (data: UserFormValues) => {
    userStore
      .login(data)
      .then(() => {})
      .catch(() => {});
  };
  const initialValues = {
    email: "",
    password: "",
    error: null,
  };
  return (
    <Formik
      initialValues={initialValues}
      onSubmit={onLogin}
      enableReinitialize
      validationSchema={schema}
    >
      {({ handleSubmit, isSubmitting }) => (
        <Form
          onSubmit={handleSubmit}
          className="space-y-3 max-w-[600px] w-full px-8 md:p-12"
        >
          <div>
            <p className="text-xl font-bold">Log in to continue</p>
          </div>
          <div className="space-y-2 ">
            <div>
              <MyTextInput
                name="email"
                placeholder="Email"
                prefix={<AiOutlineUser size={21} />}
              />
            </div>
            <div>
              <MyPasswordInput
                name="password"
                placeholder="Password"
                prefix={<AiOutlineKey size={17} />}
              />
            </div>
            <Button
              type="primary"
              className="w-full border bg-blue-400"
              htmlType="submit"
              loading={isSubmitting}
            >
              Login
            </Button>
          </div>
          <Flex justify="space-between">
            <Button type="link" className="text-blue-700" href="/auth/register">
              Create an account
            </Button>
            <Button
              type="link"
              className="text-blue-700"
              href="/auth/forgot-password"
            >
              Can't log in?
            </Button>
          </Flex>
        </Form>
      )}
    </Formik>
  );
}

export default LoginForm;
