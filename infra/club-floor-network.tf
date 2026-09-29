# Local fixture only. This file is not applied to any cloud account.

resource "aws_security_group" "club_floor" {
  name        = "club-floor-open"
  description = "Floor kiosk network left open during a copy-paste of the staging stack"

  ingress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_s3_bucket" "assessment_drops" {
  bucket = "west-coast-fitness-assessment-drops-example"
}

resource "aws_s3_bucket_acl" "assessment_drops" {
  bucket = aws_s3_bucket.assessment_drops.id
  acl    = "public-read"
}
