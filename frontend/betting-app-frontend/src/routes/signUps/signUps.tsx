// SignUps.tsx
import { useState } from 'react';
import SignUpModal from './signUpModule';
import './style.css';

const SignUps = () => {
    const listOfTypes: string[] = [
        "Allsvenskan - Sweden",
        "FIFA Women's World Cup",
        "Superettan - Sweden",
        "UEFA Champions League Women",
        "UEFA Champions League"
    ];

    const [selectedType, setSelectedType] = useState<string | null>(null);

    const handleCardClick = (type: string) => {
        setSelectedType(type);
    };

    const closeModal = () => {
        setSelectedType(null);
    };

    return (
        <div className="signup-container">
            <h3>Välj typ</h3>
            <div className="card-grid">
                {listOfTypes.map((type, index) => (
                    <div key={index} className="card" onClick={() => handleCardClick(type)}>
                        {type}
                    </div>
                ))}
            </div>

            {selectedType && (
                <SignUpModal
                    title={selectedType}
                    show={!!selectedType}
                    onClose={closeModal}
                />
            )}
        </div>
    );
};

export default SignUps;
