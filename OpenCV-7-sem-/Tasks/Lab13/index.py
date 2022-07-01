import cv2

cap = cv2.VideoCapture(0)

while True:
    ret, img = cap.read()
    cv2.imshow("camera", img)
    if cv2.waitKey(10) == 27:  # Клавиша Esc
        break

while True:
    ret, img = cap.read()
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY )
    sobel_horizontal = cv2.Sobel(gray, cv2.CV_16S, 1, 0)
    sobel_vertical = cv2.Sobel(gray, cv2.CV_16S, 0, 1)
    mat_hor = cv2.convertScaleAbs(sobel_horizontal)
    mat_vert = cv2.convertScaleAbs(sobel_vertical)
    cv2.imshow('Sobel_X', mat_hor)
    cv2.imshow('Sobel_Y', mat_vert)
    if cv2.waitKey(10) == 27:
        break

while True:
    ret, frame = cap.read()
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    laplacian = cv2.Laplacian(gray, cv2.CV_64F)
    mat = cv2.convertScaleAbs(laplacian)
    cv2.imshow('Laplacian', mat)
    if cv2.waitKey(10) == 27:
        break

while True:
    ret, frame = cap.read()
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    canny = cv2.Canny(gray, 100, 200)
    cv2.imshow('Canny', canny)
    if cv2.waitKey(10) == 27:
        break

cap.release()
cv2.destroyAllWindows()
