import { Link } from "react-router-dom"

const Home =()=>{


    return (
        <div>
            <p>Prenumenera på bettingtips!</p>
                <Link to={'/signup'}>Signup</Link>
        </div>
    )
}

export default Home