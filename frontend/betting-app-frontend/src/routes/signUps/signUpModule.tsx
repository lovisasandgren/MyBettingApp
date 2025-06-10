import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import './style.css';

interface ModalProps {
    title: string;
    show: boolean;
    onClose: () => void;
}

const SignUpModal: React.FC<ModalProps> = ({ title, show, onClose }) => {
    const [mail, setMail] = useState("");
    const [showErrormsg, setShowErrormsg] = useState(false);

    const isValidEmail = (email: string) => {
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return regex.test(email);
    };

    const handleSend = () => {
        if (isValidEmail(mail)) {
            const raw = JSON.stringify({ mail });
            console.log(raw);
            onClose(); // Stäng modalen efter skickat
        } else{
            setShowErrormsg(true)
        }
    };

    const showError = !isValidEmail(mail);

    return (
        <Modal show={show} onHide={onClose}>
            <Modal.Header closeButton>
                <Modal.Title>{title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group className="mb-3" controlId="signup.mail">
                        <Form.Label>Mailadress</Form.Label>
                        <Form.Control
                            type="email"
                            autoFocus
                            value={mail}
                            onChange={(e) => setMail(e.target.value)}
                            isInvalid={showErrormsg && showError}
                        />
                        {showErrormsg && (
                            <Form.Control.Feedback type="invalid">
                                Ange en giltig e-postadress.
                            </Form.Control.Feedback>
                        )}

                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onClose}>
                    Stäng
                </Button>
                <Button
                    variant="primary"
                    onClick={handleSend}
                    disabled={!mail}
                >
                    Skicka
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default SignUpModal;
