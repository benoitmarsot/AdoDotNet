
const SignOut = (props) => {
    const onSignOut=props.onSignOut;
    onSignOut();
    return (
        <div>
            <h1>Sign Out</h1>
            <p>Thank you for using this application.</p>
            <p>Click the link below to sign in again.</p>
            <p><a href="/signin">Sign In</a></p>
        </div>
    );
};

export default SignOut;
