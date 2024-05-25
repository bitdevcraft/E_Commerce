import { Button, Flex } from "antd";
import { Form, Formik } from "formik";
import * as yup from "yup";
import { MyPasswordInput, MyTextInput } from "../../app/common/form";
import { useStore } from "../../app/store/store";
import { UserFormValues } from "../../app/models/user";

const schema = yup
  .object({
    email: yup
      .string()
      .required("Email is required")
      .matches(/^[\w-\\.]+@([\w-]+\.)+[\w-]{2,4}$/, "Invalid Email"),
    password: yup
      .string()
      .required("Password is Required")
      .matches(
        /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/,
        "Password must contain at least 8 characters, including one number, one lowercase and one uppercase letter"
      ),
    confirm_password: yup
      .string()
      .oneOf([yup.ref("password")], "Passwords do not match")
      .required("Confirm Password is required"),
    firstName: yup.string().required("First Name is required"),
    lastName: yup.string().required("Last Name is required"),
    username: yup.string().required("Username is required"),
  })
  .required();

function RegisterForm() {
  const { userStore } = useStore();
  const onRegister = (data: UserFormValues) => {
    userStore.register(data);
  };

  const initialValues = {
    firstName: "",
    lastName: "",
    email: "",
    username: "",
    password: "",
    confirm_password: "",
    error: null,
  };

  return (
    <Formik
      initialValues={initialValues}
      onSubmit={onRegister}
      enableReinitialize
      validationSchema={schema}
    >
      {({ handleSubmit, isSubmitting }) => (
        <Form
          onSubmit={handleSubmit}
          className="space-y-3 px-8 md:p-12 max-w-[600px] w-full"
        >
          <div>
            <p className="text-xl font-bold">Sign up to continue</p>
          </div>
          <div className="space-y-2 w-full">
            <div className="flex gap-2 w-full">
              <MyTextInput name="firstName" placeholder="First Name" />
              <MyTextInput name="lastName" placeholder="Last Name" />
            </div>
            <div>
              <MyTextInput name="username" placeholder="Username" />
            </div>
            <div>
              <MyTextInput name="email" placeholder="Email" />
            </div>
            <div>
              <MyPasswordInput name="password" placeholder="Password" />
            </div>
            <div>
              <MyPasswordInput
                name="confirm_password"
                placeholder="Re-Type Password"
              />
            </div>
          </div>
          <p className="text-xs text-gray-700">
            By signing up, I accept the Vite Terms of Service and acknowledge
            the Privacy Policy.
          </p>
          <Button
            type="primary"
            className="w-full border bg-blue-400"
            htmlType="submit"
            // disabled={isSubmitting || !dirty || !isValid}
            loading={isSubmitting}
          >
            Sign up
          </Button>
          <Flex justify="center">
            <Button type="link" className="text-blue-700" href="/auth/login">
              Already have an account? Log in
            </Button>
          </Flex>
        </Form>
      )}
    </Formik>
  );
}

export default RegisterForm;
