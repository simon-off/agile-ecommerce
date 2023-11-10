import ThemedInput from "../../components/ThemedInput";
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useToast } from "../../hooks/useToast";
import { apiDomain } from "../../helpers/apiDomain";
import getCookieByName from "../../helpers/getCookieByName";
import { Eye, EyeOff } from "lucide-react";

function ChangePassword() {
  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [oldPasswordIsHidden, setOldPasswordIsHidden] = useState(true);
  const [newPasswordIsHidden, setNewPasswordIsHidden] = useState(true);
  const [confirmNewPasswordIsHidden, setConfirmNewPasswordIsHidden] = useState(true);
  const toast = useToast();
  const authToken = getCookieByName("Authorization");
  const navigate = useNavigate();

  useEffect(() => {
    // Login failed
    if (!authToken) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, navigate]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updateData = {
      oldPassword: oldPassword,
      newPassword: newPassword,
    };

    try {
      if (newPassword !== confirmPassword) {
        throw new Error("Passwords do not match!");
      }

      const response = await fetch(`${apiDomain.https}/api/account/changepassword`, {
        method: "PUT",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
        body: JSON.stringify(updateData),
      });

      if (!response.ok) {
        throw new Error("Something went wrong. Make sure that all information is valid.");
      }

      toast.add("Changes successfully saved.");
      navigate("/profile/edit");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <div className="edit-profile-page">
      <h1>Change Password</h1>
      <form onSubmit={handleSubmit}>
        <ThemedInput
          label="Old Password"
          required
          error={"This field is required"}
          value={oldPassword}
          type={oldPasswordIsHidden ? "password" : "text"}
          // type="password"
          onChange={(e) => setOldPassword(e.target.value)}
          maxLength={100}
          minLength={8}
        >
          <button type="button" onClick={() => setOldPasswordIsHidden(!oldPasswordIsHidden)}>
            {oldPasswordIsHidden ? <EyeOff /> : <Eye />}
          </button>
        </ThemedInput>
        <ThemedInput
          label="New Password"
          required
          error={"This field is required"}
          value={newPassword}
          type={newPasswordIsHidden ? "password" : "text"}
          regex={
            "^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\\d)(?=.*[@$!%*?&])[A-ZÅÄÖa-zåäö\\d@$!%*?&]{8,}$"
          }
          // type="password"
          onChange={(e) => setNewPassword(e.target.value)}
          maxLength={100}
          minLength={8}
        >
          <button type="button" onClick={() => setNewPasswordIsHidden(!newPasswordIsHidden)}>
            {newPasswordIsHidden ? <EyeOff /> : <Eye />}
          </button>
        </ThemedInput>
        <ThemedInput
          label="Confrim Password"
          required
          error={"This field is required"}
          value={confirmPassword}
          type={confirmNewPasswordIsHidden ? "password" : "text"}
          // type="password"
          regex={
            "^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\\d)(?=.*[@$!%*?&])[A-ZÅÄÖa-zåäö\\d@$!%*?&]{8,}$"
          }
          onChange={(e) => setConfirmPassword(e.target.value)}
          maxLength={100}
          minLength={8}
        >
          <button
            type="button"
            onClick={() => setConfirmNewPasswordIsHidden(!confirmNewPasswordIsHidden)}
          >
            {confirmNewPasswordIsHidden ? <EyeOff /> : <Eye />}
          </button>
        </ThemedInput>
        <div className="button-container">
          <button className="button button-black" type="submit">
            Change Password
          </button>
          <Link to={"/profile/edit"} className="button go-back-button">
            Go Back
          </Link>
        </div>
      </form>
    </div>
  );
}

export default ChangePassword;
